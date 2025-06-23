using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public record Plant(string PlantName, string PlantAbbr, string PlantType, string PlantFullName);

    public class PlantsDictionary
    {
        public int PlantNo;

        public static Dictionary<int, Plant> Plants = new Dictionary<int, Plant>()
        {
            {  1, new Plant("OCC", "OCC", "OCC", "Operations Control Center") },
            {  2, new Plant("Diemer TP", "DmrTP", "TP", "Diemer Treatment Plant") },
            {  3, new Plant("Jensen TP", "JWTP", "TP", "Jensen Treatment Plant") },
            {  4, new Plant("Mills TP", "MilTP", "TP", "Mills Treatment Plant") },
            {  5, new Plant("Weymouth TP", "WeyTP", "TP", "Weymouth Treat Plant") },
            {  6, new Plant("Skinner TP", "SknTP", "TP", "Skinner Treat Plant") },
            {  7, new Plant("Desert OCC", "DsOCC", "DsOCC", "Desert Operations Control Center") },
            {  8, new Plant("Intake PP", "InPP", "PP", "Intake Pumping Plant") },
            {  9, new Plant("Gene PP", "GePP", "PP", "Gene Pumping Plant") },
            { 10, new Plant("Iron PP", "IrPP", "PP", "Operations Control Center") },
            { 11, new Plant("Eagle PP", "EaPP", "PP", "Eagle Mountain Pumping Plant") },
            { 12, new Plant("Hinds PP", "HiPP", "PP", "Hinds Pumping Plant") },
            { 13, new Plant("DVL", "DVL", "DVL", "Diamond Valley Lake") }
        };
    }
}
