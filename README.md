TIAJScripter enables scripting of TIA Portal functions from Javascript using the Openness API.
Currently it's mainly geared towards manipulating Unified HMIs.
In many cases it's just a one-to-one mapping of the C# API to Javascript, but there are a few differences.

When a script is started there is a predefined object named 'TIA'. It has the following members:

TIA.TiaPortal       the Portal Object
TIA.SelectedPlcs    All PLCs selected when the script was started. Corresponds to the PlcSoftware type in Openness.
TIA.SelectedHmis    All HMI device (excluding Unified) selected when the script was started. Corresponds to the HmiTarget type in Openness.
TIA.SelectedUnifiedHmis    All Unified HMI device selected when the script was started. Corresponds to the HmiSoftware type in Openness.
TIA.Enum            Enumeration constants for most of the enumerations in Siemens.Engineering.HmiUnified.UI.Enum and Siemens.Engineering.HmiUnified.UI.Events, i.e. TIA.Enum.PropertyEventType.QualityCodeChange .

When setting multiple attributes it's more efficient to use the SetAttrs (the SetAttribute method is not useable with Javascript) method where implemented.
It takes a dictionary as argument. Each key corresponds to a property.

The HmiScreen object has some extra methods for item creation:
CreateRectangle
CreateCircle
CreateGraphicView
CreateButton
CreateTextBox
CreateFaceplate
CreatePolyline
CreateLine
CreateIOField
CreateTogleSwitch
CreateListBox
CreateSlider
CreateRadioButtonGroup
CreateCheckBoxGroup
CreateLabel

All these take the name of the new item as the first argument. The second optional argument contains property values as a dictionary.

In most cases an enum value can be replaced by a string containing the name of the enum.

An array of length 3 (\[red,green,blue]) or 4 (\[alpha,red,green,blue]) can be used as a color.
