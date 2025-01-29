using System;
using System.Runtime.InteropServices;

class Program {
    [DllImport("user32.dll")]
    static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, IntPtr dwExtraInfo); // no tenemos que mover el mouse así que no vamos a usar dx ni dy
    
    [DllImport("user32.dll")]
    static extern short GetAsyncKeyState(int vKey); // import usado para setear un hotkey y activar el autoclicker

    private const uint _leftClickdown = 0x02;
    private const uint _leftClickup = 0x04;
    private bool _enableClicker = false;
    private int _clickInterval = 200; // intervalo en milisegundos - cada cuánto clickea
}