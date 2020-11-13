using System;
using System.Collections.Generic;
using System.Text;

namespace QuorumDB
{
    public interface ICommand
    {
        void Execute();
    }

    public class optionSelect
    {
        ICommand slot;

        public optionSelect()
        {
        }

        public void setOption(ICommand command)
        {
            slot = command;
        }

        public void executeCommand()
        {
            slot.Execute();
        }
    }
}
