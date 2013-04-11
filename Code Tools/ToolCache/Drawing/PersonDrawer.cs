using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ToolCache.Equipment;

namespace ToolCache.Drawing {
    public class PersonDrawer {

        public static Boolean Draw(Graphics g, Point p, Direction d, States s, EquipmentItem head, EquipmentItem face, EquipmentItem body, EquipmentItem pants, EquipmentItem weapon) {
            if (g == null) return false;
            if (p == null) return false;

            if (pants == null || pants.Type != EquipmentTypes.Legs) return false; //Need legs for shadow layer
            if (face != null && face.Type != EquipmentTypes.Face) return false;
            if (body != null && body.Type != EquipmentTypes.Body) return false;
            if (head != null && head.Type != EquipmentTypes.Hat) return false;
            if (weapon != null && weapon.Type != EquipmentTypes.Weapon) return false;

            //The linking offsets
            Point p_offset = pants.Offset;
            Point b_offset = body==null? (short)0 : body.Offset;
            Point w_offset = weapon == null ? (short)0 : weapon.Offset;
            Point f_offset = face == null ? (short)0 : face.Offset;
            Point h_offset = head == null ? (short)0 : head.Offset;

            //The centers
            Point pantsCenter = pants.DisplayAnimation(s, d, 0).Center;
            Point shadowCenter = pants.DisplayAnimation(s, d, 1).Center;
            Point bodyCenter = body.DisplayAnimation(s, d, 0).Center;
            Point headCenter = head.DisplayAnimation(s, d, 0).Center;
            Point faceCenter = face.DisplayAnimation(s, d, 0).Center;
            Point weaponCenter = weapon.DisplayAnimation(s, d, 0).Center;

            //Calculate shadow position
            Point shadowPosition = Point.Empty;
            shadowPosition.X = p.X - shadowCenter.X;
            shadowPosition.Y = p.Y - shadowCenter.Y;

            //Calculate pants position
            Point legsPosition = Point.Empty;
            legsPosition.X = p.X - pantsCenter.X;
            legsPosition.Y = p.Y - p_offset;

            //Solve body position
            Point bodyLink = Point.Empty;
            bodyLink.X = p.X - bodyCenter.X;
            bodyLink.Y = p.Y - b_offset;

            //Solve head position
            Point headLink = Point.Empty;
            headLink.X = p.X - faceCenter.X;
            headLink.Y = p.Y - f_offset;

            //Solve headgear if possible
            Point headgearLink = Point.Empty;
            headgearLink.X = p.X - headCenter.X;
            headgearLink.Y = p.Y - h_offset;

            //Solve weapon if possible
            Point weaponLink = Point.Empty;
            weaponLink.X = p.X - weaponCenter.X;
            weaponLink.Y = p.Y - w_offset;

            ////////////////////////////////////////// DRAW STUFF

            //Draw Shadow
            pants.DisplayAnimation(s, d, 1).Draw(g, shadowPosition.X, shadowPosition.Y, 1);

            //Draw Back Weapon
            if (weapon != null) {
                weapon.DisplayAnimation(s, d, 1).Draw(g, weaponLink.X, weaponLink.Y, 1);
            }

            //Draw Legs
            pants.DisplayAnimation(s, d, 0).Draw(g, legsPosition.X, legsPosition.Y, 1);

            //Draw Body Back
            if (body != null) {
                body.DisplayAnimation(s, d, 1).Draw(g, bodyLink.X, bodyLink.Y, 1);
            }

            //Draw Head
            if (face != null) {
                face.DisplayAnimation(s, d, 0).Draw(g, headLink.X, headLink.Y, 1);
            }

            //Draw Headgear
            if (head != null) {
                head.DisplayAnimation(s, d, 0).Draw(g, headgearLink.X, headgearLink.Y, 1);
            }

            //Draw Body Front
            if (body != null) {
                body.DisplayAnimation(s, d, 0).Draw(g, bodyLink.X, bodyLink.Y, 1);
            }

            //Draw Weapon Front
            if (weapon != null) {
                weapon.DisplayAnimation(s, d, 0).Draw(g, weaponLink.X, weaponLink.Y, 1);
            }

            return true;
        }

    }
}
