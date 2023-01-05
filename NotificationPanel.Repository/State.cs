using System;

namespace NotificationPanel.Repository
{
    internal class State
    {

        public void main()
        {
            context ct = new context();
            startstate startstate1 = new startstate();

            StopState stopsrtate1 = new StopState();

            ct.setStates(startstate1);

            ct.GetState(stopsrtate1);


        }




        public interface states
        {
            void doAction();
        }
        public class startstate : states
        {
            public void doAction()
            {
                Console.WriteLine("abc");

            }

            public string toString()
            {
                return "start state";
            }
        }
        public class StopState : states
        {
            public void doAction()
            {

                Console.WriteLine("stop emp state");
            }

            public string toString()
            {
                return "stop state";
            }
        }
        public class context
        {
            public states state;

            public context()
            {
                state = null;
            }
        
            public void setStates (states st)
            {
                this.state = st;
                this.state.doAction();
            }
            public states GetState()
            {
                return state;
            }

        }
    }
}
