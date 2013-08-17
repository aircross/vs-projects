object MainForm: TMainForm
  Left = 340
  Top = 182
  Width = 470
  Height = 221
  HelpContext = 1001
  BorderIcons = [biSystemMenu, biMinimize]
  Caption = 'BeiYang Net Printer Status Monitor Demo V2.001'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  KeyPreview = True
  OldCreateOrder = False
  Position = poScreenCenter
  OnKeyDown = FormKeyDown
  PixelsPerInch = 96
  TextHeight = 13
  object GroupBox1: TGroupBox
    Left = 24
    Top = 16
    Width = 417
    Height = 57
    TabOrder = 1
    object Label2: TLabel
      Left = 100
      Top = 28
      Width = 54
      Height = 13
      Caption = 'IP Address:'
    end
    object IPEdit1: TEdit
      Left = 161
      Top = 24
      Width = 33
      Height = 21
      MaxLength = 3
      TabOrder = 0
      Text = '192'
    end
    object IPEdit2: TEdit
      Left = 200
      Top = 24
      Width = 33
      Height = 21
      MaxLength = 3
      TabOrder = 1
      Text = '168'
    end
    object IPEdit3: TEdit
      Left = 240
      Top = 24
      Width = 33
      Height = 21
      MaxLength = 3
      TabOrder = 2
      Text = '192'
    end
    object IPEdit4: TEdit
      Left = 280
      Top = 24
      Width = 33
      Height = 21
      MaxLength = 3
      TabOrder = 3
      Text = '168'
    end
    object SetIP: TRadioButton
      Left = 8
      Top = -4
      Width = 113
      Height = 22
      Caption = 'Setting IP Address'
      Checked = True
      TabOrder = 4
      TabStop = True
      OnClick = SetIPClick
    end
  end
  object GroupBox2: TGroupBox
    Left = 24
    Top = 88
    Width = 417
    Height = 57
    TabOrder = 2
    object Label3: TLabel
      Left = 83
      Top = 26
      Width = 73
      Height = 13
      Caption = 'IP Address List:'
    end
    object IPList: TComboBox
      Left = 162
      Top = 24
      Width = 145
      Height = 21
      Enabled = False
      ItemHeight = 13
      ItemIndex = 0
      TabOrder = 0
      Text = '<NULL>'
      OnChange = IPListChange
      Items.Strings = (
        '<NULL>')
    end
    object AutoGetIP: TRadioButton
      Left = 8
      Top = 0
      Width = 153
      Height = 17
      Caption = 'Auto Get Device IP Address'
      TabOrder = 1
      OnMouseDown = AutoGetIPMouseDown
    end
  end
  object PrintDemo: TButton
    Left = 100
    Top = 152
    Width = 75
    Height = 25
    Caption = 'Printing Demo'
    TabOrder = 3
    OnClick = PrintDemoClick
  end
  object PrinterStatus: TButton
    Left = 196
    Top = 152
    Width = 75
    Height = 25
    Caption = 'Printer Status'
    TabOrder = 0
    OnClick = PrinterStatusClick
  end
  object ExitButton: TButton
    Left = 292
    Top = 152
    Width = 75
    Height = 25
    Caption = 'Exit'
    TabOrder = 4
    OnClick = ExitButtonClick
  end
end
