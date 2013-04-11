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

            if (head != null && head.Type != EquipmentTypes.Hat) return false;
            if (body == null || body.Type != EquipmentTypes.Body) return false;
            if (pants == null || pants.Type != EquipmentTypes.Legs) return false; //Need legs for shadow layer
            if (face == null || face.Type != EquipmentTypes.Face) return false;
            if (weapon != null && weapon.Type != EquipmentTypes.Weapon) return false;

            //The linking offsets
            Point pd_offset = pants.GetLinkDown(d);
            Point pu_offset = pants.GetLinkUp(d);
            Point bd_offset = body.GetLinkDown(d);
            Point bu_offset = body.GetLinkUp(d);
            Point bm_offset = body.GetLinkMiddle(d);
            Point fd_offset = face.GetLinkDown(d);
            Point hd_offset = head == null ? Point.Empty : head.GetLinkDown(d);
            Point wd_offset = weapon == null ? Point.Empty : weapon.GetLinkDown(d);

            //The centers
            Point pantsCenter = pants.DisplayAnimation(s, d, 0).Center;
            Point shadowCenter = pants.DisplayAnimation(s, d, 1).Center;
            Point bodyCenter = body.DisplayAnimation(s, d, 0).Center;

            //Calculate shadow position
            Point shadowPosition = Point.Empty;
            shadowPosition.X = p.X - shadowCenter.X;
            shadowPosition.Y = p.Y - shadowCenter.Y;

            //Calculate pants position
            Point legsPosition = Point.Empty;
            legsPosition.X = p.X - pd_offset.X;
            legsPosition.Y = p.Y - pd_offset.Y;

            //Solve body position
            Point bodyLink = Point.Empty;
            bodyLink.X = p.X - pd_offset.X + pu_offset.X - bd_offset.X;
            bodyLink.Y = p.Y - pd_offset.Y + pu_offset.Y - bd_offset.Y;

            //Solve head position
            Point headLink = Point.Empty;
            headLink.X = p.X - pd_offset.X + pu_offset.X - bd_offset.X + bu_offset.X - fd_offset.X;
            headLink.Y = p.Y - pd_offset.Y + pu_offset.Y - bd_offset.Y + bu_offset.Y - fd_offset.Y;

            //Solve headgear if possible
            Point headgearLink = Point.Empty;
            headgearLink.X = p.X - pd_offset.X + pu_offset.X - bd_offset.X + bu_offset.X - hd_offset.X;
            headgearLink.Y = p.Y - pd_offset.Y + pu_offset.Y - bd_offset.Y + bu_offset.Y - hd_offset.Y;

            //Solve weapon if possible
            Point weaponLink = Point.Empty;
            weaponLink.X = p.X - pd_offset.X + pu_offset.X - bd_offset.X + bm_offset.X - wd_offset.X;
            weaponLink.Y = p.Y - pd_offset.Y + pu_offset.Y - bd_offset.Y + bm_offset.Y - wd_offset.Y;

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
            body.DisplayAnimation(s, d, 1).Draw(g, bodyLink.X, bodyLink.Y, 1);

            //Draw Head
            face.DisplayAnimation(s, d, 0).Draw(g, headLink.X, headLink.Y, 1);

            //Draw Headgear
            if (head != null) {
                head.DisplayAnimation(s, d, 0).Draw(g, headgearLink.X, headgearLink.Y, 1);
            }

            //Draw Body Front
            body.DisplayAnimation(s, d, 0).Draw(g, bodyLink.X, bodyLink.Y, 1);

            //Draw Weapon Front
            if (weapon != null) {
                weapon.DisplayAnimation(s, d, 0).Draw(g, weaponLink.X, weaponLink.Y, 1);
            }

            return true;
        }

    }
}
