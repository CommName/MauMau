﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIG.AV.Karte;

namespace MauMauGame
{
    public interface View
    {
        void updateTalon(Karta k,Boja b);
        void updateYourHand(List<Karta> k);
        void updateEnemyHand(int karte);
        void updatePoints(int your, int enemy);

        void krajRunde(int tvoj, int protivnik);

        void kazna(bool k);
        void kupi(bool k);
        void yourTurn(bool t);
    }
}
