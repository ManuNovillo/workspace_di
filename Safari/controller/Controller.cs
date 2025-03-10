﻿using Safari.model;
using Safari.model.position;
using Safari.model.seres;

namespace Safari.controller
{
    public class Controller
    {
        private MiSafari safari;

        private int filas;
        private int columnas;

        public Controller(MiSafari safari) 
        {
            String.IsNullOrEmpty("");
            this.safari = safari;
        }

        public void startSafari(int filas, int columnas)
        {
            this.filas = filas;
            this.columnas = columnas;
            safari.setDimensiones(filas, columnas);
            safari.startSafari();

            VentanaSafari form = new VentanaSafari(this);
            form.ShowDialog();
        }

        public int getFilasMaximas()
        {
            return safari.getFilasMaximas();
        }

        public int getColumnasMaximas()
        {
            return safari.getColumnasMaximas();
        }

        public int getFilasMinimas()
        {
            return safari.getFilasMinimas();
        }

        public int getColumnasMinimas()
        {
            return safari.getColumnasMinimas();
        }

        public void step()
        {
            safari.step();
        }

        public List<String> getSeres()
        {
            return safari.getSeres();
        }

        internal void restartSafari()
        {
            safari.restart();
        }

        public int getNumeroPlantas()
        {
            return safari.NumeroPlantas;
        }

        public int getNumeroLeones()
        {
            return safari.NumeroLeones;
        }

        public int getNumeroGacelas()
        {
            return safari.NumeroGacelas;
        }

        public int getNumeroSeres()
        {
            return safari.NumeroSeres;
        }

        public int getNumeroPasos()
        {
            return safari.NumeroPasos;
        }

        // Examen 4
        public bool noQuedanSeres()
        {
            return safari.NoQuedanSeres;
        }

        // Examen 4
        public bool soloQuedanPlantas()
        {
            return safari.SoloQuedanPlantas;
        }

        public bool simuacionTerminada()
        {
            return safari.SimulacionTerminada;
        }

        public int getNumeroElefantes()
        {
            return safari.NumeroElefantes;
        }
    }
}
