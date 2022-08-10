using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;

namespace OpenessExt
{
    public class EnumLookup : DynamicObject
    {
        public class EnumType : DynamicObject
        {
            private readonly Type enum_type;

            public EnumType(Type type)
            {
                enum_type = type;
            }

            public override bool TryGetMember(GetMemberBinder binder,
                                 out object result)
            {
                try
                {
                    object enumeration = Enum.Parse(enum_type, binder.Name);
                    result = enumeration;
                    return true;
                }
                catch (Exception)
                {
                    string[] enum_names = enum_type.GetEnumNames();
                    throw new Exception("Enum " + enum_type.Name + " has the following alternatives " + string.Join(", ", enum_names));
                }

            }
        }
        static readonly Type[] types = {
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiScreenEventType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiAggregationMode),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiAlarmBlock),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiAlarmControlEventType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiAlarmSourceType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiAlarmStatisticBlock),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiBackgroundFillMode),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiBarEventType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiBarMode),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiButtonEventType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiButtonStyleItemClass),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiCapType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiCheckBoxGroupEventType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiCircleEventType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiCircleSegmentEventType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiCircularArcEventType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiClockEventType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiComboBoxEventType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiContentMode),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiDashType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiDataGridHeaderType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiDetailedParameterControlBlock),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiDetailedParameterControlEventType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiDotNetControlContainerEventType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiEditMode),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiEllipseEventType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiEllipseSegmentEventType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiEllipticalArcEventType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiFaceplateContainerEventType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiFillDirection),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiFillPattern),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiFlashingRate),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiFontName),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiFontStrikeOut),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiFontWeight),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiFunctionTrendControlEventType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiGaugeEventType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiGraphicStretchMode),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiGraphicViewEventType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiGridColoringMode),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiGridLine),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiGridSelectionMode),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiHorizontalAlignment),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiIOFieldEventType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiIOFieldType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiLineEndType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiLineEventType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiLineJoinType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiListBoxEventType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiMarkerType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiMediaControlEventType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiOrientation),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiOverviewParameterControlBlock),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiPeakIndicator),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiPolygonEventType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiPolylineEventType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiProcessControlEventType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiProcessIndicatorMode),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiQuality),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiRadioButtonGroupEventType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiRectangleEventType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiRotationCenterPlacement),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiScaleMode),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiScalingType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiScreenEventType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiScreenWindowAdaption),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiScreenWindowEventType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiScrollBarVisibility),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiSelectionMode),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiSimpleGridLine),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiSimplePosition),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiSliderEventType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiSortDirection),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiSystemDiagnosisControlBlock),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiSystemDiagnosisControlEventType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiTextBoxEventType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiTextPosition),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiTextTrimming),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiTextWrapping),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiTimeRangeBase),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiTimeRangeType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiToggleSwitchEventType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiTrendCompanionEventType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiTrendCompanionMode),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiTrendControlEventType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiTrendInfoBlock),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiTrendMode),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiVerticalAlignment),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiVideoOutput),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiVisibleAlarms),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiWebControlEventType),
            typeof(Siemens.Engineering.HmiUnified.UI.Enum.HmiWindowFlag),

            typeof(Siemens.Engineering.HmiUnified.UI.Events.PropertyEventType),
        };
        public override bool TryGetMember(GetMemberBinder binder,
                                  out object result)
        {
            foreach (Type enum_type in types)
            {

                if (enum_type.Name == binder.Name)
                {
                    result = new EnumType(enum_type);
                    return true;
                }

            }
            throw new Exception();
        }
    }
}
