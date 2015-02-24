﻿// This file is Part of CalDavSynchronizer (https://sourceforge.net/projects/outlookcaldavsynchronizer/)
// Copyright (c) 2015 Gerhard Zehetbauer 
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as
// published by the Free Software Foundation, either version 3 of the
// License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
// 
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Linq;
using System.Windows.Forms;
using CalDavSynchronizer.Contracts;
using Microsoft.Office.Interop.Outlook;

namespace CalDavSynchronizer.Ui
{
  public partial class OptionsForm : Form
  {
    private readonly NameSpace _session;

    public OptionsForm (NameSpace session)
    {
      InitializeComponent();
      _session = session;
    }


    public static bool EditOptions (NameSpace session, Options[] options, out Options[] changedOptions)
    {
      changedOptions = null;
      var form = new OptionsForm (session);
      form.OptionsList = options;
      var shouldSave = form.ShowDialog() == DialogResult.OK;
      if (shouldSave)
        changedOptions = form.OptionsList;
      return shouldSave;
    }

    private Options[] OptionsList
    {
      get
      {
        return _tabControl.TabPages
            .Cast<TabPage>()
            .Select (tp => ((OptionsDisplayControl) tp.Controls[0]).Options)
            .ToArray();
      }
      set
      {
        foreach (var options in value)
        {
          AddTabPage (options);
        }
      }
    }

    private void AddTabPage (Options options)
    {
      var optionsControl = new OptionsDisplayControl (_session);
      optionsControl.Options = options;

      var tabPage = new TabPage (options.Name);
      optionsControl.OnDeletionRequested += delegate { _tabControl.TabPages.Remove (tabPage); };
      optionsControl.OnProfileNameChanged += delegate (object sender, string e)
      {
        tabPage.Text = e;
      };

      tabPage.Controls.Add (optionsControl);
      optionsControl.Dock = DockStyle.Fill;

      _tabControl.TabPages.Add (tabPage);
    }


    private void OkButton_Click (object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
    }

    private void _addProfileButton_Click (object sender, EventArgs e)
    {
      AddTabPage (Options.CreateDefault (string.Empty, string.Empty));
    }
  }
}