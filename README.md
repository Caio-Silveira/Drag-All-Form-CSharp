# Drag-All-Form-CSharp

## Description

This is a C# code example demonstrating how to enable drag and drop functionality for form controls (such as buttons, labels, etc.) within a Windows Forms application. With this implementation, you can click and drag any control to reposition it on the form.

## How to Use

1. Clone or download this repository to your local machine.
2. Open the solution in Visual Studio.
3. Build the project to ensure everything is set up correctly.
4. Run the application to see the demo in action.
5. To use the drag and drop feature in your own project:
   - Copy the `Main.cs` file or the required code into your project.
   - Make sure to include the necessary namespaces and references.
   - Call the `AddDragEventsToControls` method in your form's constructor to enable drag and drop for your controls.
## Video Example
[Watch the video demo here](https://streamable.com/pki9fj)
Credits
This code example was created by Caio Silveira.

Feel free to use this code in your own projects and don't forget to give credit to the original author. If you find any issues or have suggestions for improvements, please feel free to open an issue or submit a pull request.

Happy coding! 😊

## Example Code

```csharp
namespace Example
{
    public partial class Main : Form
    {
        #region Variables
        private bool isDragging = false;
        private Point lastCursor;
        private Point lastForm;
        #endregion

        public Main()
        {
            InitializeComponent();
            AddDragEventsToControls(this);
        }

        private void AddDragEventsToControls(Control container)
        {
            // Loop through all controls inside the container (form or panel)
            foreach (Control control in container.Controls)
            {
                // Add mouse events for child controls
                control.MouseDown += Control_MouseDown;
                control.MouseMove += Control_MouseMove;
                control.MouseUp += Control_MouseUp;

                // If the control is a container (e.g., a panel or group), call recursively to add events to its child controls
                if (control.Controls.Count > 0)
                {
                    AddDragEventsToControls(control);
                }
            }
        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastCursor = Cursor.Position;
                lastForm = this.Location;
            }
        }

        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int xDiff = Cursor.Position.X - lastCursor.X;
                int yDiff = Cursor.Position.Y - lastCursor.Y;
                this.Location = new Point(lastForm.X + xDiff, lastForm.Y + yDiff);
            }
        }

        private void Control_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }
    }
}
```

## Credits

This code example was created by [Caio Silveira](https://github.com/Caio-Silveira).

Feel free to use and modify the code in your own projects. If you encounter any issues or have suggestions for improvements, do not hesitate to open an issue or submit a pull request.

Happy coding! 😊
