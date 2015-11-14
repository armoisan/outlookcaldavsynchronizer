﻿namespace CalDavSynchronizer.Ui
{
  partial class EventMappingConfigurationForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose (bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose ();
      }
      base.Dispose (disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent ()
    {
      this._cancelButton = new System.Windows.Forms.Button();
      this._okButton = new System.Windows.Forms.Button();
      this._mapReminderCheckBox = new System.Windows.Forms.CheckBox();
      this._mapAttendeesCheckBox = new System.Windows.Forms.CheckBox();
      this._mapBodyCheckBox = new System.Windows.Forms.CheckBox();
      this.SuspendLayout();
      // 
      // _cancelButton
      // 
      this._cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this._cancelButton.Location = new System.Drawing.Point(189, 111);
      this._cancelButton.Name = "_cancelButton";
      this._cancelButton.Size = new System.Drawing.Size(75, 23);
      this._cancelButton.TabIndex = 0;
      this._cancelButton.Text = "Cancel";
      this._cancelButton.UseVisualStyleBackColor = true;
      // 
      // _okButton
      // 
      this._okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this._okButton.Location = new System.Drawing.Point(108, 111);
      this._okButton.Name = "_okButton";
      this._okButton.Size = new System.Drawing.Size(75, 23);
      this._okButton.TabIndex = 1;
      this._okButton.Text = "OK";
      this._okButton.UseVisualStyleBackColor = true;
      this._okButton.Click += new System.EventHandler(this._okButton_Click);
      // 
      // _mapReminderCheckBox
      // 
      this._mapReminderCheckBox.AutoSize = true;
      this._mapReminderCheckBox.Location = new System.Drawing.Point(12, 12);
      this._mapReminderCheckBox.Name = "_mapReminderCheckBox";
      this._mapReminderCheckBox.Size = new System.Drawing.Size(95, 17);
      this._mapReminderCheckBox.TabIndex = 2;
      this._mapReminderCheckBox.Text = "Map Reminder";
      this._mapReminderCheckBox.UseVisualStyleBackColor = true;
      // 
      // _mapAttendeesCheckBox
      // 
      this._mapAttendeesCheckBox.AutoSize = true;
      this._mapAttendeesCheckBox.Location = new System.Drawing.Point(12, 35);
      this._mapAttendeesCheckBox.Name = "_mapAttendeesCheckBox";
      this._mapAttendeesCheckBox.Size = new System.Drawing.Size(98, 17);
      this._mapAttendeesCheckBox.TabIndex = 3;
      this._mapAttendeesCheckBox.Text = "Map Attendees";
      this._mapAttendeesCheckBox.UseVisualStyleBackColor = true;
      // 
      // _mapBodyCheckBox
      // 
      this._mapBodyCheckBox.AutoSize = true;
      this._mapBodyCheckBox.Location = new System.Drawing.Point(12, 58);
      this._mapBodyCheckBox.Name = "_mapBodyCheckBox";
      this._mapBodyCheckBox.Size = new System.Drawing.Size(74, 17);
      this._mapBodyCheckBox.TabIndex = 4;
      this._mapBodyCheckBox.Text = "Map Body";
      this._mapBodyCheckBox.UseVisualStyleBackColor = true;
      // 
      // EventMappingConfigurationForm
      // 
      this.AcceptButton = this._okButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this._cancelButton;
      this.ClientSize = new System.Drawing.Size(276, 146);
      this.ControlBox = false;
      this.Controls.Add(this._mapBodyCheckBox);
      this.Controls.Add(this._mapAttendeesCheckBox);
      this.Controls.Add(this._mapReminderCheckBox);
      this.Controls.Add(this._okButton);
      this.Controls.Add(this._cancelButton);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "EventMappingConfigurationForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.Text = "Appointment Mapping";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button _cancelButton;
    private System.Windows.Forms.Button _okButton;
    private System.Windows.Forms.CheckBox _mapReminderCheckBox;
    private System.Windows.Forms.CheckBox _mapAttendeesCheckBox;
    private System.Windows.Forms.CheckBox _mapBodyCheckBox;
  }
}