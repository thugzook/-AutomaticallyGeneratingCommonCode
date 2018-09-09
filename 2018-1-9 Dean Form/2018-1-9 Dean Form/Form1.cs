﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace _2018_1_9_Dean_Form
{
    public partial class Form1 : Form
    {
        public override bool AllowDrop { get => base.AllowDrop; set => base.AllowDrop = value; }
        public override AnchorStyles Anchor { get => base.Anchor; set => base.Anchor = value; }
        public override Point AutoScrollOffset { get => base.AutoScrollOffset; set => base.AutoScrollOffset = value; }

        public override LayoutEngine LayoutEngine => base.LayoutEngine;

        public override Image BackgroundImage { get => base.BackgroundImage; set => base.BackgroundImage = value; }
        public override ImageLayout BackgroundImageLayout { get => base.BackgroundImageLayout; set => base.BackgroundImageLayout = value; }

        protected override bool CanRaiseEvents => base.CanRaiseEvents;

        public override ContextMenu ContextMenu { get => base.ContextMenu; set => base.ContextMenu = value; }
        public override ContextMenuStrip ContextMenuStrip { get => base.ContextMenuStrip; set => base.ContextMenuStrip = value; }
        public override Cursor Cursor { get => base.Cursor; set => base.Cursor = value; }

        protected override Cursor DefaultCursor => base.DefaultCursor;

        protected override Padding DefaultMargin => base.DefaultMargin;

        protected override Size DefaultMaximumSize => base.DefaultMaximumSize;

        protected override Size DefaultMinimumSize => base.DefaultMinimumSize;

        protected override Padding DefaultPadding => base.DefaultPadding;

        public override DockStyle Dock { get => base.Dock; set => base.Dock = value; }
        protected override bool DoubleBuffered { get => base.DoubleBuffered; set => base.DoubleBuffered = value; }

        public override bool Focused => base.Focused;

        public override Font Font { get => base.Font; set => base.Font = value; }
        public override Color ForeColor { get => base.ForeColor; set => base.ForeColor = value; }
        public override RightToLeft RightToLeft { get => base.RightToLeft; set => base.RightToLeft = value; }

        protected override bool ScaleChildren => base.ScaleChildren;

        public override ISite Site { get => base.Site; set => base.Site = value; }

        protected override bool ShowKeyboardCues => base.ShowKeyboardCues;

        protected override bool ShowFocusCues => base.ShowFocusCues;

        protected override ImeMode ImeModeBase { get => base.ImeModeBase; set => base.ImeModeBase = value; }

        public override Rectangle DisplayRectangle => base.DisplayRectangle;

        public override BindingContext BindingContext { get => base.BindingContext; set => base.BindingContext = value; }

        protected override bool CanEnableIme => base.CanEnableIme;

        public override Size AutoScaleBaseSize { get => base.AutoScaleBaseSize; set => base.AutoScaleBaseSize = value; }
        public override bool AutoScroll { get => base.AutoScroll; set => base.AutoScroll = value; }
        public override bool AutoSize { get => base.AutoSize; set => base.AutoSize = value; }
        public override AutoValidate AutoValidate { get => base.AutoValidate; set => base.AutoValidate = value; }
        public override Color BackColor { get => base.BackColor; set => base.BackColor = value; }

        protected override CreateParams CreateParams => base.CreateParams;

        protected override ImeMode DefaultImeMode => base.DefaultImeMode;

        protected override Size DefaultSize => base.DefaultSize;

        public override Size MaximumSize { get => base.MaximumSize; set => base.MaximumSize = value; }
        public override Size MinimumSize { get => base.MinimumSize; set => base.MinimumSize = value; }
        public override bool RightToLeftLayout { get => base.RightToLeftLayout; set => base.RightToLeftLayout = value; }

        protected override bool ShowWithoutActivation => base.ShowWithoutActivation;

        public override string Text { get => base.Text; set => base.Text = value; }
        string fileLoc { get; set; }
        public double numSlot { get; set; }

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e){
            
        }

        
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFileLocation.Text = folderBrowserDialog1.SelectedPath + @"\Test.L5X";
                fileLoc = folderBrowserDialog1.SelectedPath;
            }
            this.TopMost = true;
        }
        private void btnTxtGen_Click(object sender, EventArgs e)
        {
            //Create an array of "conditions"
            string[] conditions = new string[9] { dropDown1.Text, dropDown2.Text, dropDown3.Text,
                                                    dropDown4.Text, dropDown5.Text, dropDown6.Text,
                                                    dropDown7.Text, dropDown8.Text, dropDown9.Text};
            string path = txtFileLocation.Text;
            if (path == "") // No path entered
            {
                // Initializes the variables to pass to the MessageBox.Show method.

                string message = "You did not enter a file path. Please choose a location for the file and start again.";
                string caption = "File Path Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);
                return;
            }
            int z = 0;
            foreach (string x in conditions)
            {
                if (z == numSlot)
                    break;
                if (x == "")
                {
                    string message = "Please fill all available dropdowns with a part.";
                    string caption = "Missing parts";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;

                    // Displays the MessageBox.

                    result = MessageBox.Show(message, caption, buttons);
                    return;
                }
                
                z++;
                
            }
            double counter = 0; // used to track value of "Number="x""
            double internalCounter = 0; //Used to track increments within the card prompt

            //initial lines at line 6545
            File.AppendAllLines(path, new[] { "<Programs Use=\"Context\">\n" +
                                                "<Program Use=\"Context\" Name=\"MainProgram\">\n" +
                                                "<Routines Use=\"Context\">\n" +
                                                "<Routine Use=\"Context\" Name=\"slotmap\">\n" +
                                                "<RLLContent Use=\"Context\">"});
            
            //Loops through all parts
            for (int i = 0; i <= numSlot; i++)
            {
                
                File.AppendAllLines(path, new[] { "<Rung Use=\"Target\" Number=\"" + counter + "\" Type=\"N\">" });
                File.AppendAllLines(path, new[] { "<Text>" });
                if (i == 0)
                {
                    File.AppendAllLines(path, new[] { "<![CDATA[XIC(eac_dint.0)OTE(slot_map[0].Digital[1]);]]>" });
                }
                else
                {
                    switch (conditions[i - 1])
                    {

                        case "Part 1":
                            //This is for part 1
                            File.AppendAllLines(path, new[] { "<![CDATA[MOV(Local:" + i + ":I.Ctr0CurrentCount,slot_map[" + i + "].encoder.current_count[" + "############ Is this supposed to be \"i\" or stay as the value 1? ####################" + "]);]]>" });
                            break;
                        case "Local 2":
                            //This is for part "Local 2:"
                            //this requires 4 iterations to finish the prompt for this card
                            internalCounter = 0;
                            for (int j = 0; j <= 3; j++)
                            {
                                if ((j != 3) && (j % 2 == 0)) //if this is the 1st and 3rd loop
                                {
                                    File.AppendAllLines(path, new[] { "<![CDATA[NEQ(Local:" + i + ":I.Ch" + internalCounter + "RxID,slot_map[" + i + "].Serial[" + internalCounter + "].idRX)[MOV(Local:" + i + ":I.Ch" + internalCounter + "RxDataLength,slot_map[" + i + "].Serial[" + internalCounter + "].lenRX) ,CPS(Local:" + i + ":I.Ch" + internalCounter + "RxData[0],slot_map[" + i + "].Serial[" + internalCounter + "].dataRX[0],Local:" + i + ":I.Ch" + internalCounter + "RxDataLength) ,MOV(Local:" + i + ":I.Ch" +internalCounter + "RxID,slot_map[" + i + "].Serial[" + internalCounter + "].idRX) ];]]>" });
                                    File.AppendAllLines(path, new[] { "</Text>\n</Rung>" });
                                    counter++;
                                    File.AppendAllLines(path, new[] { "<Rung Use=\"Target\" Number=\"" + counter + "\" Type=\"N\">" });
                                    File.AppendAllLines(path, new[] { "<Text>" });
                                }
                                else if ((j == 1)) //2nd iteration
                                {
                                    File.AppendAllLines(path, new[] { "<![CDATA[[COP(slot_map[" + i + "].Serial[" + internalCounter + "].dataTX[0],Local:" + i + ":O.Ch" + internalCounter + "TxData[0],slot_map[" + i + "].Serial[" + internalCounter + "].lenTX) ,MOV(slot_map[" + i + "].Serial[" + internalCounter + "].lenTX,Local:" + i + ":O.Ch" + internalCounter + "TxDataLength) ,MOV(slot_map[" + i + "].Serial[" + internalCounter + "].idTX,Local:" + i + ":O.Ch" + internalCounter + "TxID) ];]]>" });
                                    File.AppendAllLines(path, new[] { "</Text>\n</Rung>" });
                                    counter++;
                                    internalCounter++;
                                    File.AppendAllLines(path, new[] { "<Rung Use=\"Target\" Number=\"" + counter + "\" Type=\"N\">" });
                                    File.AppendAllLines(path, new[] { "<Text>" });
                                }
                                else //last iteration
                                {
                                    File.AppendAllLines(path, new[] { "<![CDATA[[COP(slot_map[" + i + "].Serial[" + internalCounter + "].dataTX[0],Local:" + i + ":O.Ch" + internalCounter + "TxData[0],slot_map[" + i + "].Serial[" + internalCounter + "].lenTX) ,MOV(slot_map[" + i + "].Serial[" + internalCounter + "].lenTX,Local:" + i + ":O.Ch" + internalCounter + "TxDataLength) ,MOV(slot_map[" + i + "].Serial[" + internalCounter + "].idTX,Local:" + i + ":O.Ch" + internalCounter + "TxID) ];]]>" });
                                }        
                            }
                            break;
                        case "IF8":
                            //this is for part IF8. Takes up 8 slots
                            internalCounter = 0;
                            for (int j = 0; j <= 7; j++)
                            {
                                if (j != 7)
                                {
                                    File.AppendAllLines(path, new[] { "<![CDATA[MOV(Local:" + i + ":I.Ch" + j + "Data,slot_map[" + i + "].Analog[" + internalCounter + "]);]]>" });
                                    File.AppendAllLines(path, new[] { "</Text>\n</Rung>" });
                                    counter++;
                                    internalCounter++;
                                    File.AppendAllLines(path, new[] { "<Rung Use=\"Target\" Number=\"" + counter + "\" Type=\"N\">" });
                                    File.AppendAllLines(path, new[] { "<Text>" });
                                }
                                else 
                                {
                                    File.AppendAllLines(path, new[] { "<![CDATA[MOV(Local:" + i + ":I.Ch" + j + "Data,slot_map[" + i + "].Analog[" + internalCounter + "]);]]>" });
                                }
                            }
                            break;
                        case "OF8V":
                            //this is for part OF8V. Takes up 8 slots
                            internalCounter = 0;
                            for (int j = 0; j <= 7; j++)
                            {
                                if (j != 7)
                                {
                                    File.AppendAllLines(path, new[] { "<![CDATA[MOV(slot_map[" + i + "].Analog[" + internalCounter + "],Local:" + i + ":O.Ch" + internalCounter + "Data);]]>" });
                                    File.AppendAllLines(path, new[] { "</Text>\n</Rung>" });
                                    counter++;
                                    internalCounter++;
                                    File.AppendAllLines(path, new[] { "<Rung Use=\"Target\" Number=\"" + counter + "\" Type=\"N\">" });
                                    File.AppendAllLines(path, new[] { "<Text>" });
                                }
                                else
                                {
                                    File.AppendAllLines(path, new[] { "<![CDATA[MOV(slot_map[" + i + "].Analog[" + internalCounter + "],Local:" + i + ":O.Ch" + internalCounter + "Data);]]>" });
                                }
                            }
                            break;
                        case "IQ16":
                            //this is for part IQ16. Takes up 16 slots
                            internalCounter = 0;
                            for (int j = 0; j <= 15; j++)
                            {
                                if (j != 15)
                                {
                                    File.AppendAllLines(path, new[] { "<![CDATA[XIC(Local:" + i + ":I.Data." + internalCounter + ")OTE(slot_map[" + i + "].Digital[" + internalCounter + "]);]]>" });
                                    File.AppendAllLines(path, new[] { "</Text>\n</Rung>" });
                                    counter++;
                                    internalCounter++;
                                    File.AppendAllLines(path, new[] { "<Rung Use=\"Target\" Number=\"" + counter + "\" Type=\"N\">" });
                                    File.AppendAllLines(path, new[] { "<Text>" });
                                }
                                else
                                {
                                    File.AppendAllLines(path, new[] { "<![CDATA[XIC(Local:" + i + ":I.Data." + internalCounter + ")OTE(slot_map[" + i + "].Digital[" + internalCounter + "]);]]>" });
                                }
                            }
                            break;
                        case "OB16":
                            //this is for part OB16. Takes up 16 slots
                            internalCounter = 0;
                            for (int j = 0; j <= 15; j++)
                            {
                                if (j != 15)
                                {
                                    File.AppendAllLines(path, new[] { "<![CDATA[XIC(slot_map[" + i + "].Digital[" + internalCounter + "])OTE(Local:" + i + ":O.Data." + internalCounter + ");]]>" });
                                    File.AppendAllLines(path, new[] { "</Text>\n</Rung>" });
                                    counter++;
                                    internalCounter++;
                                    File.AppendAllLines(path, new[] { "<Rung Use=\"Target\" Number=\"" + counter + "\" Type=\"N\">" });
                                    File.AppendAllLines(path, new[] { "<Text>" });
                                }
                                else
                                {
                                    File.AppendAllLines(path, new[] { "<![CDATA[XIC(slot_map[" + i + "].Digital[" + internalCounter + "])OTE(Local:" + i + ":O.Data." + internalCounter + ");]]>" });
                                }
                            }
                            break;
                    }      
                    
                    }
                File.AppendAllLines(path, new[] { "</Text>\n</Rung>" });
                counter++;
            }

            File.AppendAllLines(path, new[] { "</RLLContent>\n" +
                                                "</Routine>\n" +
                                                "</Routines>\n" +
                                                "</Program>\n" +
                                                "</Programs>\n" +
                                                "</Controller>\n</RSLogix5000Content>"});
        }

        private void dropdownSlots_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            numSlot = Convert.ToDouble(dropdownSlots.Text);
            Control[] labels = { label1, label2, label3, label4, label5, label6, label7, label8, label9 };
            Control[] dropDown = { dropDown1, dropDown2, dropDown3, dropDown4, dropDown5, dropDown6, dropDown7, dropDown8, dropDown9 };
            List<Control> controlCollectionLbl = new List<Control>(labels);
            List<Control> controlCollectionDrop = new List<Control>(dropDown);

            // make generate visible
            txtFileLocation.Visible = true;
            btnTxtGen.Visible = true;
            btnBrowse.Visible = true;

            //zip both lists and foreach through them
            int i = 0;
            i = 0;
            foreach (var nw in labels.Zip(dropDown, Tuple.Create))
            {
                nw.Item1.Visible = false;
                nw.Item2.Visible = false;
            }

            foreach (var nw in labels.Zip(dropDown, Tuple.Create))
            {
                nw.Item1.Visible = true;
                nw.Item2.Visible = true;
                i++;
                if (i == numSlot)
                    break;
            }

        }

        public Form1(IContainer components, ComboBox dropDown1, Label label1, Label label2, ComboBox dropDown2, Label label3, ComboBox dropDown3, Button btnTxtGen, bool allowDrop, AnchorStyles anchor, Point autoScrollOffset, Image backgroundImage, ImageLayout backgroundImageLayout, ContextMenu contextMenu, ContextMenuStrip contextMenuStrip, Cursor cursor, DockStyle dock, bool doubleBuffered, Font font, Color foreColor, RightToLeft rightToLeft, ISite site, ImeMode imeModeBase, BindingContext bindingContext, Size autoScaleBaseSize, bool autoScroll, bool autoSize, AutoValidate autoValidate, Color backColor, Size maximumSize, Size minimumSize, bool rightToLeftLayout, string text)
        {
            this.components = components;
            this.dropDown1 = dropDown1;
            this.label1 = label1;
            this.label2 = label2;
            this.dropDown2 = dropDown2;
            this.label3 = label3;
            this.dropDown3 = dropDown3;
            this.btnTxtGen = btnTxtGen;
            AllowDrop = allowDrop;
            Anchor = anchor;
            AutoScrollOffset = autoScrollOffset;
            BackgroundImage = backgroundImage;
            BackgroundImageLayout = backgroundImageLayout;
            ContextMenu = contextMenu;
            ContextMenuStrip = contextMenuStrip;
            Cursor = cursor;
            Dock = dock;
            DoubleBuffered = doubleBuffered;
            Font = font;
            ForeColor = foreColor;
            RightToLeft = rightToLeft;
            Site = site;
            ImeModeBase = imeModeBase;
            BindingContext = bindingContext;
            AutoScaleBaseSize = autoScaleBaseSize;
            AutoScroll = autoScroll;
            AutoSize = autoSize;
            AutoValidate = autoValidate;
            BackColor = backColor;
            MaximumSize = maximumSize;
            MinimumSize = minimumSize;
            RightToLeftLayout = rightToLeftLayout;
            Text = text;
        }



        public override bool Equals(object obj) => base.Equals(obj);

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override object InitializeLifetimeService()
        {
            return base.InitializeLifetimeService();
        }

        public override ObjRef CreateObjRef(Type requestedType)
        {
            return base.CreateObjRef(requestedType);
        }

        protected override object GetService(Type service)
        {
            return base.GetService(service);
        }

        protected override AccessibleObject GetAccessibilityObjectById(int objectId)
        {
            return base.GetAccessibilityObjectById(objectId);
        }

        public override Size GetPreferredSize(Size proposedSize)
        {
            return base.GetPreferredSize(proposedSize);
        }

        protected override AccessibleObject CreateAccessibilityInstance()
        {
            return base.CreateAccessibilityInstance();
        }

        protected override void DestroyHandle()
        {
            base.DestroyHandle();
        }

        protected override void InitLayout()
        {
            base.InitLayout();
        }

        protected override bool IsInputChar(char charCode)
        {
            return base.IsInputChar(charCode);
        }

        protected override bool IsInputKey(Keys keyData)
        {
            return base.IsInputKey(keyData);
        }

        protected override void NotifyInvalidate(Rectangle invalidatedArea)
        {
            base.NotifyInvalidate(invalidatedArea);
        }

        protected override void OnAutoSizeChanged(EventArgs e)
        {
            base.OnAutoSizeChanged(e);
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
        }

        protected override void OnBindingContextChanged(EventArgs e)
        {
            base.OnBindingContextChanged(e);
        }

        protected override void OnCausesValidationChanged(EventArgs e)
        {
            base.OnCausesValidationChanged(e);
        }

        protected override void OnContextMenuChanged(EventArgs e)
        {
            base.OnContextMenuChanged(e);
        }

        protected override void OnContextMenuStripChanged(EventArgs e)
        {
            base.OnContextMenuStripChanged(e);
        }

        protected override void OnCursorChanged(EventArgs e)
        {
            base.OnCursorChanged(e);
        }

        protected override void OnDockChanged(EventArgs e)
        {
            base.OnDockChanged(e);
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
        }

        protected override void OnNotifyMessage(Message m)
        {
            base.OnNotifyMessage(m);
        }

        protected override void OnParentBackColorChanged(EventArgs e)
        {
            base.OnParentBackColorChanged(e);
        }

        protected override void OnParentBackgroundImageChanged(EventArgs e)
        {
            base.OnParentBackgroundImageChanged(e);
        }

        protected override void OnParentBindingContextChanged(EventArgs e)
        {
            base.OnParentBindingContextChanged(e);
        }

        protected override void OnParentCursorChanged(EventArgs e)
        {
            base.OnParentCursorChanged(e);
        }

        protected override void OnParentEnabledChanged(EventArgs e)
        {
            base.OnParentEnabledChanged(e);
        }

        protected override void OnParentFontChanged(EventArgs e)
        {
            base.OnParentFontChanged(e);
        }

        protected override void OnParentForeColorChanged(EventArgs e)
        {
            base.OnParentForeColorChanged(e);
        }

        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            base.OnParentRightToLeftChanged(e);
        }

        protected override void OnParentVisibleChanged(EventArgs e)
        {
            base.OnParentVisibleChanged(e);
        }

        protected override void OnPrint(PaintEventArgs e)
        {
            base.OnPrint(e);
        }

        protected override void OnTabIndexChanged(EventArgs e)
        {
            base.OnTabIndexChanged(e);
        }

        protected override void OnTabStopChanged(EventArgs e)
        {
            base.OnTabStopChanged(e);
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
        }

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            base.OnControlRemoved(e);
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);
        }

        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            base.OnDragEnter(drgevent);
        }

        protected override void OnDragOver(DragEventArgs drgevent)
        {
            base.OnDragOver(drgevent);
        }

        protected override void OnDragLeave(EventArgs e)
        {
            base.OnDragLeave(e);
        }

        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            base.OnDragDrop(drgevent);
        }

        protected override void OnGiveFeedback(GiveFeedbackEventArgs gfbevent)
        {
            base.OnGiveFeedback(gfbevent);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
        }

        protected override void OnHelpRequested(HelpEventArgs hevent)
        {
            base.OnHelpRequested(hevent);
        }

        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            base.OnInvalidated(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
        }

        protected override void OnMarginChanged(EventArgs e)
        {
            base.OnMarginChanged(e);
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
        }

        protected override void OnMouseCaptureChanged(EventArgs e)
        {
            base.OnMouseCaptureChanged(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
        }

        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
        }

        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
        }

        protected override void OnQueryContinueDrag(QueryContinueDragEventArgs qcdevent)
        {
            base.OnQueryContinueDrag(qcdevent);
        }

        protected override void OnRegionChanged(EventArgs e)
        {
            base.OnRegionChanged(e);
        }

        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            base.OnPreviewKeyDown(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
        }

        protected override void OnChangeUICues(UICuesEventArgs e)
        {
            base.OnChangeUICues(e);
        }

        protected override void OnSystemColorsChanged(EventArgs e)
        {
            base.OnSystemColorsChanged(e);
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            base.OnValidating(e);
        }

        protected override void OnValidated(EventArgs e)
        {
            base.OnValidated(e);
        }

        public override bool PreProcessMessage(ref Message msg)
        {
            return base.PreProcessMessage(ref msg);
        }

        protected override bool ProcessKeyEventArgs(ref Message m)
        {
            return base.ProcessKeyEventArgs(ref m);
        }

        protected override bool ProcessKeyMessage(ref Message m)
        {
            return base.ProcessKeyMessage(ref m);
        }

        public override void ResetBackColor()
        {
            base.ResetBackColor();
        }

        public override void ResetCursor()
        {
            base.ResetCursor();
        }

        public override void ResetFont()
        {
            base.ResetFont();
        }

        public override void ResetForeColor()
        {
            base.ResetForeColor();
        }

        public override void ResetRightToLeft()
        {
            base.ResetRightToLeft();
        }

        public override void Refresh()
        {
            base.Refresh();
        }

        public override void ResetText()
        {
            base.ResetText();
        }

        protected override Size SizeFromClientSize(Size clientSize)
        {
            return base.SizeFromClientSize(clientSize);
        }

        protected override void OnImeModeChanged(EventArgs e)
        {
            base.OnImeModeChanged(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
        }

        protected override void OnRightToLeftChanged(EventArgs e)
        {
            base.OnRightToLeftChanged(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        protected override void OnPaddingChanged(EventArgs e)
        {
            base.OnPaddingChanged(e);
        }

        protected override Point ScrollToControl(Control activeControl)
        {
            return base.ScrollToControl(activeControl);
        }

        protected override void OnScroll(ScrollEventArgs se)
        {
            base.OnScroll(se);
        }

        protected override void OnAutoValidateChanged(EventArgs e)
        {
            base.OnAutoValidateChanged(e);
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(value);
        }

        protected override void AdjustFormScrollbars(bool displayScrollbars)
        {
            base.AdjustFormScrollbars(displayScrollbars);
        }

        protected override Control.ControlCollection CreateControlsInstance()
        {
            return base.CreateControlsInstance();
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
        }

        protected override void DefWndProc(ref Message m)
        {
            base.DefWndProc(ref m);
        }

        protected override bool ProcessMnemonic(char charCode)
        {
            return base.ProcessMnemonic(charCode);
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
        }

        protected override void OnBackgroundImageChanged(EventArgs e)
        {
            base.OnBackgroundImageChanged(e);
        }

        protected override void OnBackgroundImageLayoutChanged(EventArgs e)
        {
            base.OnBackgroundImageLayoutChanged(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
        }

        protected override void OnHelpButtonClicked(CancelEventArgs e)
        {
            base.OnHelpButtonClicked(e);
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        protected override void OnMaximizedBoundsChanged(EventArgs e)
        {
            base.OnMaximizedBoundsChanged(e);
        }

        protected override void OnMaximumSizeChanged(EventArgs e)
        {
            base.OnMaximumSizeChanged(e);
        }

        protected override void OnMinimumSizeChanged(EventArgs e)
        {
            base.OnMinimumSizeChanged(e);
        }

        protected override void OnInputLanguageChanged(InputLanguageChangedEventArgs e)
        {
            base.OnInputLanguageChanged(e);
        }

        protected override void OnInputLanguageChanging(InputLanguageChangingEventArgs e)
        {
            base.OnInputLanguageChanging(e);
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
        }

        protected override void OnMdiChildActivate(EventArgs e)
        {
            base.OnMdiChildActivate(e);
        }

        protected override void OnMenuStart(EventArgs e)
        {
            base.OnMenuStart(e);
        }

        protected override void OnMenuComplete(EventArgs e)
        {
            base.OnMenuComplete(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }

        protected override void OnRightToLeftLayoutChanged(EventArgs e)
        {
            base.OnRightToLeftLayoutChanged(e);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            return base.ProcessDialogKey(keyData);
        }

        protected override bool ProcessDialogChar(char charCode)
        {
            return base.ProcessDialogChar(charCode);
        }

        protected override bool ProcessKeyPreview(ref Message m)
        {
            return base.ProcessKeyPreview(ref m);
        }

        protected override bool ProcessTabKey(bool forward)
        {
            return base.ProcessTabKey(forward);
        }

        protected override void Select(bool directed, bool forward)
        {
            base.Select(directed, forward);
        }

        protected override void ScaleCore(float x, float y)
        {
            base.ScaleCore(x, y);
        }

        protected override Rectangle GetScaledBounds(Rectangle bounds, SizeF factor, BoundsSpecified specified)
        {
            return base.GetScaledBounds(bounds, factor, specified);
        }

        protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
        {
            base.ScaleControl(factor, specified);
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, width, height, specified);
        }

        protected override void SetClientSizeCore(int x, int y)
        {
            base.SetClientSizeCore(x, y);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        protected override void UpdateDefaultButton()
        {
            base.UpdateDefaultButton();
        }

        protected override void OnResizeBegin(EventArgs e)
        {
            base.OnResizeBegin(e);
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
        }

        protected override void OnStyleChanged(EventArgs e)
        {
            base.OnStyleChanged(e);
        }

        public override bool ValidateChildren()
        {
            return base.ValidateChildren();
        }

        public override bool ValidateChildren(ValidationConstraints validationConstraints)
        {
            return base.ValidateChildren(validationConstraints);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        
    }
}
