using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb
{
    public static class TurnSubject
    {
        static List<TurnObserver> observers = new List<TurnObserver>();

        public static void Attach(TurnObserver observer) {
            observers.Add(observer);
        }
        public static void Detach(TurnObserver observer) {
            observers.Remove(observer);
        }
        public static void Notify() {
            foreach (var observer in observers)
                observer.Update();
        }
    }
}
