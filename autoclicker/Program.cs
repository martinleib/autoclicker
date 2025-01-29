using System;
using System.Runtime.InteropServices;

class Program {
    [DllImport("user32.dll")]
    static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, IntPtr dwExtraInfo);
    
    [DllImport("user32.dll")]
    static extern short GetAsyncKeyState(int vKey);

    private const uint _leftClickdown = 0x02;
    private const uint _leftClickup = 0x04;
    private const int _hotkey = 0x26;
    // https://learn.microsoft.com/en-us/windows/win32/inputdev/virtual-key-codes

    private bool _enableClicker = false;
    private int _clickInterval = 50;

    static void Main()
    {
        Console.WriteLine("Autoclicker. Usá la tecla 'Up' (ARROW_KEY_UP) para activar/desactivar.");
        Program p = new Program();
        p.Run();
    }

    private void Run()
    {
        while (true)
        {
            if (GetAsyncKeyState(_hotkey) < 0)
            {
                _enableClicker = !_enableClicker;
                Console.WriteLine(_enableClicker ? "Autoclicker activado" : "Autoclicker desactivado");
                Thread.Sleep(500);
            }

            if (_enableClicker)
            {
                MouseClick();
            }
            Thread.Sleep(_clickInterval);
        }
    }
    
    private void MouseClick()
    {
        mouse_event(_leftClickdown, 0, 0, 0, IntPtr.Zero);
        mouse_event(_leftClickup, 0, 0, 0, IntPtr.Zero);
    }
}