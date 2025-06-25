using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public record PlantDto(string PlantName, string PlantAbbr, string PlantType, string PlantFullName);

    public class PlantsDictionary
    {
        public int PlantNo;

        public static Dictionary<int, PlantDto> Plants = new Dictionary<int, PlantDto>()
        {
            {  1, new PlantDto("OCC", "OCC", "OCC", "Operations Control Center") },
            {  2, new PlantDto("Diemer TP", "DmrTP", "TP", "Diemer Treatment Plant") },
            {  3, new PlantDto("Jensen TP", "JWTP", "TP", "Jensen Treatment Plant") },
            {  4, new PlantDto("Mills TP", "MilTP", "TP", "Mills Treatment Plant") },
            {  5, new PlantDto("Weymouth TP", "WeyTP", "TP", "Weymouth Treat Plant") },
            {  6, new PlantDto("Skinner TP", "SknTP", "TP", "Skinner Treat Plant") },
            {  7, new PlantDto("Desert OCC", "DsOCC", "DsOCC", "Desert Operations Control Center") },
            {  8, new PlantDto("Intake PP", "InPP", "PP", "Intake Pumping Plant") },
            {  9, new PlantDto("Gene PP", "GePP", "PP", "Gene Pumping Plant") },
            { 10, new PlantDto("Iron PP", "IrPP", "PP", "Operations Control Center") },
            { 11, new PlantDto("Eagle PP", "EaPP", "PP", "Eagle Mountain Pumping Plant") },
            { 12, new PlantDto("Hinds PP", "HiPP", "PP", "Hinds Pumping Plant") },
            { 13, new PlantDto("DVL", "DVL", "DVL", "Diamond Valley Lake") }
        };
    }
}
