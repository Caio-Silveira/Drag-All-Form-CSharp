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
            // Percorre todos os controles dentro do container (formulário ou painel)
            foreach (Control control in container.Controls)
            {
                // Adiciona os eventos para os controles filhos
                control.MouseDown += Control_MouseDown;
                control.MouseMove += Control_MouseMove;
                control.MouseUp += Control_MouseUp;

                // Se o controle é um container (por exemplo, um painel ou grupo), chama recursivamente para adicionar aos seus controles filhos
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
