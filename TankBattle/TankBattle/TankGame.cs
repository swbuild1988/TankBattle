﻿using System;
using System.Timers;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;

namespace TankBattle
{
    class TankGame : IDisposable
    {
        public Point Range { get; set; }

        private int _fps = 60;
        private System.Timers.Timer _refreshTimer = new System.Timers.Timer();
        private Control _canvas;
        private Control _window;
        private Hashtable _keyDowns = new Hashtable();
        private Hashtable _actions = new Hashtable();
        private List<GameObj> _elements = new List<GameObj>();


        public Tank Tank { get; set; }
        public List<Wall> Walls { get; set; }
        
        public TankGame(int fps, Control ctrl, Control window, Point range)
        {
            this._fps = fps;
            this._canvas = ctrl;
            this._window = window;
            this.Range = range;
            init();
        }

        public void setFPS(int fps)
        {
            this._fps = fps;
        }

        public void registerActions(string key, Action action)
        {
            setHashTableValue(_actions, key, action);
        }


        private void init()
        {
            Walls = new List<Wall>();
            for (int i = 0; i < 6; i++)
            {
                Wall w = new Wall(this, new Point(i * 60, i * 80));
                Walls.Add(w);
            }
            Tank = new Tank(this);

            _elements.Add(Tank);
            _elements.AddRange(Walls);

            #region 初始化Timer，并设置为单次触发
            _refreshTimer.Interval = 1000.0 / _fps;
            _refreshTimer.AutoReset = false;
            _refreshTimer.Elapsed += _refreshTimer_Elapsed;
            _refreshTimer.Start();
            #endregion

            #region 注册控件事件
            _canvas.Paint += Canvas_Paint;
            _window.KeyDown += _window_KeyDown;
            _window.KeyUp += _window_KeyUp;
            #endregion
        }

        #region 控件事件

        private void _window_KeyUp(object sender, KeyEventArgs e)
        {
            string key = e.KeyCode.ToString().ToLower();
            setHashTableValue(_keyDowns, key, false);
        }

        private void _window_KeyDown(object sender, KeyEventArgs e)
        {
            setHashTableValue(_keyDowns, e.KeyCode.ToString().ToLower(), true);
        }

        private void setHashTableValue(Hashtable table, string key, object value)
        {
            if (table.ContainsKey(key))
                table[key] = value;
            else
                table.Add(key, value);
        }

        #endregion

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            foreach (GameObj item in _elements) item.Draw(e.Graphics);
        }

        private void _refreshTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            foreach (DictionaryEntry item in _actions)
            {
                if (_keyDowns.ContainsKey(item.Key) && (bool)_keyDowns[item.Key])
                {
                    Action ac = _actions[item.Key] as Action;
                    ac.Invoke();
                }
            }

            _canvas.Invalidate();
            
            _refreshTimer.Interval = 1000.0 / _fps;
            _refreshTimer.Start();
        }

        #region Dispose

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _refreshTimer.Dispose();
            }
        }

        #endregion

    }
}
