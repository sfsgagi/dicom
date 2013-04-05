using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DicomUtils;
using AForge.Imaging.Filters;
using System.Drawing;
using System.Windows.Forms;

namespace DicomViewer.DicomUtils
{
    /// <summary>
    /// The 'Command' abstract class
    /// </summary>
    abstract class Command
    {

        public abstract void Execute();
        public abstract void UnExecute();

    }

    class ChangeImageCommand : Command
    {
        ImageSettings oldValue;
        ImageSettings newValue;
        PictureView pictureView;

        public ChangeImageCommand(PictureView form1, ImageSettings oldValue, ImageSettings newValue)
        {
            this.oldValue = oldValue;
            this.newValue = newValue;
            this.pictureView = form1;
        }

        public override void Execute()
        {
            pictureView.ImageSettings = newValue;
        }

        public override void UnExecute()
        {
            pictureView.ImageSettings = oldValue;
        }
    }

    class AddAnnotationCommand : Command
    {
        AnnotationManager annotationManager;
        Annotation annotation;

        public AddAnnotationCommand(AnnotationManager annotationManager, Annotation annotation)
        {
            this.annotationManager = annotationManager;
            this.annotation = annotation;
        }

        public override void Execute()
        {
            annotationManager.AddAnnotation(annotation);
        }

        public override void UnExecute()
        {
            annotationManager.DeleteAnnotation(annotation);
        }
    }

    class DeleteAnnotationCommand : Command
    {
        AnnotationManager annotationManager;
        Annotation annotation;
        
        public DeleteAnnotationCommand(AnnotationManager annotationManager)
        {
            this.annotationManager = annotationManager;
            this.annotation = annotationManager.GetLastAnnotation();
        }

        public override void Execute()
        {
            annotationManager.DeleteLastAnnotation();
        }

        public override void UnExecute()
        {
            if (annotation != null)
            {
                annotationManager.AddAnnotation(annotation);
            }
        }
    }


    class CommandManager
    {
        List<Command> commands = new List<Command>();
        int currentCommand = 0;
        MainForm form1;

        public CommandManager(MainForm form1)
        {
            this.form1 = form1;
        }

        public void Undo()
        {
            try
            {
                commands[currentCommand - 1].UnExecute();
                currentCommand--;
                form1.RefreshGui();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void Redo()
        {
            try
            {
                commands[currentCommand].Execute();
                currentCommand++;
                form1.RefreshGui();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void Execute(Command command)
        {
            try
            {
                commands.RemoveAll(new System.Predicate<Command>(
                    delegate(Command val)
                    {
                        return commands.IndexOf(val) >= currentCommand;
                    }));

                commands.Add(command);
                command.Execute();
                currentCommand++;
                form1.RefreshGui();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public bool hasRedoCommand()
        {
            return currentCommand < commands.Count;
        }

        public bool hasUndoCommand()
        {
            return commands.Count > 0 && currentCommand > 0;
        }

        public void Clear()
        {
            currentCommand = 0;
            commands.Clear();
            form1.RefreshGui();
        }
    }
}
