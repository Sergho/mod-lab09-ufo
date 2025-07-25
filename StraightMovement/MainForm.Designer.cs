﻿namespace StraightMovement;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        controlPanel = new Panel();
        nLabel = new Label();
        nLabelText = new Label();
        epsilonLabel = new Label();
        epsilonLabelText = new Label();
        singleButton = new Button();
        multipleButton = new Button();
        toLabel = new Label();
        fromLabel = new Label();
        toLabelText = new Label();
        fromLabelText = new Label();
        canvasPanel = new Panel();
        controlPanel.SuspendLayout();
        SuspendLayout();
        // 
        // controlPanel
        // 
        controlPanel.BackColor = SystemColors.Control;
        controlPanel.Controls.Add(nLabel);
        controlPanel.Controls.Add(nLabelText);
        controlPanel.Controls.Add(epsilonLabel);
        controlPanel.Controls.Add(epsilonLabelText);
        controlPanel.Controls.Add(singleButton);
        controlPanel.Controls.Add(multipleButton);
        controlPanel.Controls.Add(toLabel);
        controlPanel.Controls.Add(fromLabel);
        controlPanel.Controls.Add(toLabelText);
        controlPanel.Controls.Add(fromLabelText);
        controlPanel.Dock = DockStyle.Left;
        controlPanel.Location = new Point(0, 0);
        controlPanel.Name = "controlPanel";
        controlPanel.Size = new Size(304, 620);
        controlPanel.TabIndex = 0;
        // 
        // nLabel
        // 
        nLabel.AutoSize = true;
        nLabel.Font = new Font("Segoe UI", 16F);
        nLabel.Location = new Point(108, 147);
        nLabel.Name = "nLabel";
        nLabel.Size = new Size(0, 30);
        nLabel.TabIndex = 9;
        // 
        // nLabelText
        // 
        nLabelText.AutoSize = true;
        nLabelText.Font = new Font("Segoe UI", 16F);
        nLabelText.Location = new Point(12, 147);
        nLabelText.Name = "nLabelText";
        nLabelText.Size = new Size(34, 30);
        nLabelText.TabIndex = 8;
        nLabelText.Text = "N:";
        // 
        // epsilonLabel
        // 
        epsilonLabel.AutoSize = true;
        epsilonLabel.Font = new Font("Segoe UI", 16F);
        epsilonLabel.Location = new Point(108, 100);
        epsilonLabel.Name = "epsilonLabel";
        epsilonLabel.Size = new Size(0, 30);
        epsilonLabel.TabIndex = 7;
        // 
        // epsilonLabelText
        // 
        epsilonLabelText.AutoSize = true;
        epsilonLabelText.Font = new Font("Segoe UI", 16F);
        epsilonLabelText.Location = new Point(12, 100);
        epsilonLabelText.Name = "epsilonLabelText";
        epsilonLabelText.Size = new Size(86, 30);
        epsilonLabelText.TabIndex = 6;
        epsilonLabelText.Text = "Epsilon:";
        // 
        // singleButton
        // 
        singleButton.Dock = DockStyle.Bottom;
        singleButton.Font = new Font("Segoe UI", 16F);
        singleButton.Location = new Point(0, 469);
        singleButton.Name = "singleButton";
        singleButton.Size = new Size(304, 76);
        singleButton.TabIndex = 5;
        singleButton.Text = "Single Simulation";
        singleButton.UseVisualStyleBackColor = true;
        singleButton.Click += singleButton_Click;
        // 
        // multipleButton
        // 
        multipleButton.Dock = DockStyle.Bottom;
        multipleButton.Font = new Font("Segoe UI", 16F);
        multipleButton.Location = new Point(0, 545);
        multipleButton.Name = "multipleButton";
        multipleButton.Size = new Size(304, 75);
        multipleButton.TabIndex = 4;
        multipleButton.Text = "Multiple Simulation";
        multipleButton.UseVisualStyleBackColor = true;
        multipleButton.Click += multipleButton_Click;
        // 
        // toLabel
        // 
        toLabel.AutoSize = true;
        toLabel.Font = new Font("Segoe UI", 16F);
        toLabel.Location = new Point(108, 55);
        toLabel.Name = "toLabel";
        toLabel.Size = new Size(0, 30);
        toLabel.TabIndex = 3;
        // 
        // fromLabel
        // 
        fromLabel.AutoSize = true;
        fromLabel.Font = new Font("Segoe UI", 16F);
        fromLabel.Location = new Point(108, 11);
        fromLabel.Name = "fromLabel";
        fromLabel.Size = new Size(0, 30);
        fromLabel.TabIndex = 2;
        // 
        // toLabelText
        // 
        toLabelText.AutoSize = true;
        toLabelText.Font = new Font("Segoe UI", 16F);
        toLabelText.Location = new Point(12, 55);
        toLabelText.Name = "toLabelText";
        toLabelText.Size = new Size(41, 30);
        toLabelText.TabIndex = 1;
        toLabelText.Text = "To:";
        // 
        // fromLabelText
        // 
        fromLabelText.AutoSize = true;
        fromLabelText.Font = new Font("Segoe UI", 16F);
        fromLabelText.Location = new Point(12, 11);
        fromLabelText.Name = "fromLabelText";
        fromLabelText.Size = new Size(69, 30);
        fromLabelText.TabIndex = 0;
        fromLabelText.Text = "From:";
        // 
        // canvasPanel
        // 
        canvasPanel.BackColor = SystemColors.ControlLightLight;
        canvasPanel.Dock = DockStyle.Right;
        canvasPanel.Location = new Point(310, 0);
        canvasPanel.Name = "canvasPanel";
        canvasPanel.Size = new Size(340, 620);
        canvasPanel.TabIndex = 1;
        canvasPanel.Paint += canvasPanel_Paint;
        // 
        // MainForm
        // 
        AutoScaleMode = AutoScaleMode.Inherit;
        ClientSize = new Size(650, 620);
        Controls.Add(controlPanel);
        Controls.Add(canvasPanel);
        Name = "MainForm";
        Text = "MainForm";
        controlPanel.ResumeLayout(false);
        controlPanel.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Panel controlPanel;
    private Panel canvasPanel;
    private Button multipleButton;
    private Label toLabel;
    private Label fromLabel;
    private Label toLabelText;
    private Label fromLabelText;
    private Button singleButton;
    private Label epsilonLabelText;
    private Label epsilonLabel;
    private Label nLabel;
    private Label nLabelText;
}
