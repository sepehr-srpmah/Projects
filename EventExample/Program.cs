using System;

namespace EventExample
{
    public delegate void Notify(); // delegate


    // Publisher class
    public class ProcessBusinessLogic
    {
        public event Notify ProcessCompleted; // event

        public void StartProcess()
        {
            System.Console.WriteLine("Process Started !");

            // Some code placed here ...

            OnProcessCompleted();
        }

        // Protected virtual method
        protected virtual void OnProcessCompleted()
        {
            // if ProcessCompleted is not null then call delegate
            // This will call the event handler methods registered with the ProcessCompleted event.
            ProcessCompleted?.Invoke();
        }
    }

    public class ProcessBusinessLogic2
    {
        // declaring an event using built-in EventHandler
        public event EventHandler ProcessCompleted;

        public void StartProcess()
        {
            System.Console.WriteLine("Process Started !");

            // Some code placed here ...

            // No event data
            OnProcessCompleted(EventArgs.Empty);
        }

        protected virtual void OnProcessCompleted(EventArgs e)
        {
            ProcessCompleted?.Invoke(this, e);
        }
    }

    public class ProcessBusinessLogic3
    {
        // declaring an event using built-in EventHandler
        public event EventHandler<bool> ProcessCompleted;

        public void StartProcess()
        {
            try
            {
                Console.WriteLine("Process Started !");

                // Some code here ...

                OnProcessCompleted(true);
            }
            catch (Exception e)
            {
                OnProcessCompleted(false);
            }
        }

        protected virtual void OnProcessCompleted(bool IsSuccessful)
        {
            ProcessCompleted?.Invoke(this, IsSuccessful);
        }
    }

    public class ProcessBusinessLogic4
    {
        // declaring an event using built-in EventHandler
        public event EventHandler<ProcessEventArgs> ProcessCompleted;

        public void StartProcess()
        {
            var data = new ProcessEventArgs();

            try
            {
                Console.WriteLine("Process Started !");

                // some code here ...

                data.IsSuccessful = true;
            }
            catch (Exception)
            {
                data.IsSuccessful = false;
            }
            finally
            {
                data.CompletionTime = DateTime.Now;
                OnProcessCompleted(data);
            }
        }

        protected virtual void OnProcessCompleted(ProcessEventArgs e)
        {
            ProcessCompleted?.Invoke(this, e);
        }
    }

    // Subscriber class
    class Program
    {


        static void Main(string[] args)
        {
            ProcessBusinessLogic4 businessLogic = new ProcessBusinessLogic4();

            // register with an event
            // The anonymous method is event handler
            businessLogic.ProcessCompleted += delegate (object sender, ProcessEventArgs e)
            {
                Console.WriteLine("Process " + (e.IsSuccessful ? "Completed Successfully" : "failed"));
                Console.WriteLine("Completion Time: {0}", e.CompletionTime);
            };

            businessLogic.StartProcess();
        }
    }
}
