﻿using System.Collections.Generic;

namespace Perspex.Xaml.Interactivity.UnitTests
{
    public class StubBehavior : PerspexObject, IBehavior
    {
        public int AttachCount
        {
            get;
            private set;
        }

        public int DetachCount
        {
            get;
            private set;
        }

        public ActionCollection Actions
        {
            get;
            private set;
        }

        public StubBehavior()
        {
            this.Actions = new ActionCollection();
        }

        public PerspexObject AssociatedObject
        {
            get;
            private set;
        }

        public void Attach(PerspexObject PerspexObject)
        {
            this.AssociatedObject = PerspexObject;
            this.AttachCount++;
        }

        public void Detach()
        {
            this.AssociatedObject = null;
            this.DetachCount++;
        }

        public IEnumerable<object> Execute(object sender, object parameter)
        {
            return Interaction.ExecuteActions(sender, this.Actions, parameter);
        }
    }

    public class StubAction : PerspexObject, IAction
    {
        private readonly object returnValue;

        public StubAction()
        {
            this.returnValue = null;
        }

        public StubAction(object returnValue)
        {
            this.returnValue = returnValue;
        }

        public object Sender
        {
            get;
            private set;
        }

        public object Parameter
        {
            get;
            private set;
        }

        public int ExecuteCount
        {
            get;
            private set;
        }

        public object Execute(object sender, object parameter)
        {
            this.ExecuteCount++;
            this.Sender = sender;
            this.Parameter = parameter;
            return this.returnValue;
        }
    }
}
