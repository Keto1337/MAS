using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieHosting
{
    class ParticipantFormObject : Panel
    {
        private SeriesDetailsEditPage parent;

        private int id_participant;

        public Label type;
        public Label participant_name;
        public Panel icon;
        public Button delete;

        public ParticipantFormObject(Form parent, int idParticipant, string participantName, string roleType, int X_loc, int Y_loc, bool delete_button = false)
        {
            IdParticipant = idParticipant;

            this.SuspendLayout();
            this.BackColor = System.Drawing.Color.Silver;
            this.Location = new System.Drawing.Point(X_loc, Y_loc);
            this.MinimumSize = new System.Drawing.Size(97, 150);
            this.Size = new System.Drawing.Size(97, 150);
            this.Anchor = AnchorStyles.Left;

            delete = new Button();
            type = new Label();
            participant_name = new Label();
            icon = new Panel();

            if (delete_button)
            {
                this.parent = (SeriesDetailsEditPage) parent;
                this.Controls.Add(delete);
            }

            this.Controls.Add(type);
            this.Controls.Add(participant_name);
            this.Controls.Add(icon);

            //
            // type
            type.AutoSize = true;
            type.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            type.Location = new System.Drawing.Point(2, 0);
            type.MinimumSize = new System.Drawing.Size(90, 20);
            type.Name = "type" + id_participant;
            type.Size = new System.Drawing.Size(90, 20);
            type.Text = roleType;
            //
            // icon
            icon.BackgroundImage = global::MovieHosting.Properties.Resources.user_icon;
            icon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            icon.Location = new System.Drawing.Point(2, 20);
            icon.Name = "icon" + id_participant;
            icon.Size = new System.Drawing.Size(90, 90);
            //
            // participant_name
            participant_name.AutoSize = true;
            participant_name.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            participant_name.Location = new System.Drawing.Point(0, 110);
            participant_name.MaximumSize = new System.Drawing.Size(95, 40);
            participant_name.MinimumSize = new System.Drawing.Size(95, 40);
            participant_name.Name = "participant_name" + id_participant;
            participant_name.Size = new System.Drawing.Size(95, 40);
            participant_name.Text = participantName;
            //
            // delete
            delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            delete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            delete.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            delete.ForeColor = System.Drawing.Color.Snow;
            delete.Location = new System.Drawing.Point(18, 38);
            delete.Name = "delete" + id_participant;
            delete.Size = new System.Drawing.Size(58, 53);
            delete.TabIndex = 20;
            delete.Text = "X";
            delete.UseVisualStyleBackColor = false;
            delete.BringToFront();
            delete.Click += new System.EventHandler(this.delete_Click);

        }

        public int IdParticipant 
        {
            get { return id_participant; }
            private set
            {
                if (value < 0) throw new ArgumentException("IdParticipant can't be less than zero");
                id_participant = value;
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            parent.RemoveParticipant(id_participant);
        }

    }
}
