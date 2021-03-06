﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ToolCache.Equipment;

namespace ToolCache.Drawing {
    public class PersonDrawer {

        public static Boolean Draw(Graphics g, Point p, Direction d, EquipmentItem shadow, EquipmentItem head, EquipmentItem face, EquipmentItem body, EquipmentItem pants, EquipmentItem weapon, bool drawWaist) {
            if (g == null) return false;
            if (p == null) return false;

            //Need face, body and legs
            if (shadow == null || shadow.Type != EquipmentTypes.Shadow) return false;
            if (pants == null || pants.Type != EquipmentTypes.Legs) return false;
            if (face == null || face.Type != EquipmentTypes.Head) return false;
            if (body == null || body.Type != EquipmentTypes.Body) return false;

            //Make sure the others are what they say as well
            if (head != null && head.Type != EquipmentTypes.Headgear) return false;
            if (weapon != null && weapon.Type != EquipmentTypes.Weapon) return false;

            //The linking offsets
            Point p_offset = pants.Offset(d);
            Point b_offset = body.Offset(d);
            Point f_offset = face.Offset(d);
            Point w_offset = weapon == null ? Point.Empty : weapon.Offset(d);
            Point h_offset = head == null ? Point.Empty : head.Offset(d);

            //The centers
            Point shadowCenter = shadow.GetCenter(d);
            Point pantsCenter = pants.GetCenter(d);
            Point bodyCenter = body.GetCenter(d);
            Point faceCenter = face.GetCenter(d);
            Point headCenter = head == null ? Point.Empty : head.GetCenter("Default", d);
            Point weaponCenter = weapon == null ? Point.Empty : weapon.GetCenter("Default", d);

            short WaistHeight = (short)(p.Y - p_offset.X);

            //Calculate shadow position
            Point shadowPosition = Point.Empty;
            shadowPosition.X = p.X - shadowCenter.X;
            shadowPosition.Y = p.Y - shadowCenter.Y;

            //Calculate pants position
            Point legsPosition = Point.Empty;
            legsPosition.X = p.X - pantsCenter.X;
            legsPosition.Y = p.Y + p_offset.Y;

            //Solve body position
            Point bodyLink = Point.Empty;
            bodyLink.X = p.X - bodyCenter.X - b_offset.X;
            bodyLink.Y = WaistHeight - b_offset.Y - bodyCenter.Y;

            //Solve head position
            Point headLink = Point.Empty;
            headLink.X = p.X - f_offset.X - faceCenter.X;
            headLink.Y = WaistHeight - f_offset.Y - faceCenter.Y;

            //Solve headgear if possible
            Point headgearLink = Point.Empty;
            headgearLink.X = p.X - h_offset.X - headCenter.X;
            headgearLink.Y = WaistHeight - h_offset.Y - headCenter.Y;

            //Solve weapon if possible
            Point weaponLink = Point.Empty;
            weaponLink.X = p.X - w_offset.X - weaponCenter.X;
            weaponLink.Y = WaistHeight - w_offset.Y - weaponCenter.Y;

            ////////////////////////////////////////// DRAW STUFF

            if(drawWaist) g.DrawLine(Pens.Red, p.X - 20, WaistHeight, p.X + 20, WaistHeight);

            //Draw Shadow
            shadow.DisplayAnimation(d, 0).Draw(g, shadowPosition.X, shadowPosition.Y, 1);

            //Draw Back Weapon
            if (weapon != null) {
                weapon.DisplayAnimation(d, 1).Draw(g, weaponLink.X, weaponLink.Y, 1);
            }

            //Draw Legs
            pants.DisplayAnimation(d, 0).Draw(g, legsPosition.X, legsPosition.Y, 1);

            //Draw Body Back
            body.DisplayAnimation(d, 1).Draw(g, bodyLink.X, bodyLink.Y, 1);

            //Draw Head
            face.DisplayAnimation(d, 0).Draw(g, headLink.X, headLink.Y, 1);

            if (d == Direction.Down) { //when heading down the layers are flipped
                //Draw Body Front
                body.DisplayAnimation(d, 0).Draw(g, bodyLink.X, bodyLink.Y, 1);

                //Draw Headgear
                if (head != null) {
                    head.DisplayAnimation(d, 0).Draw(g, headgearLink.X, headgearLink.Y, 1);
                }
            } else {
                //Draw Headgear
                if (head != null) {
                    head.DisplayAnimation(d, 0).Draw(g, headgearLink.X, headgearLink.Y, 1);
                }

                //Draw Body Front
                body.DisplayAnimation(d, 0).Draw(g, bodyLink.X, bodyLink.Y, 1);
            }

            //Draw Weapon Front
            if (weapon != null) {
                weapon.DisplayAnimation(d, 0).Draw(g, weaponLink.X, weaponLink.Y, 1);
            }

            return true;
        }

    }
}
