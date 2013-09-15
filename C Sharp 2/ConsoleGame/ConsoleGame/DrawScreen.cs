using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

public class DrawScreen
{
    // individual letters used for drawing menu heading texts
    readonly static bool[,] letterA = { { false, false, false, false, false, false, false, true, true, true, true, true, true, true }, { false, false, false, false, false, false, true, true, false, false, false, true, true, false }, { false, false, false, false, false, true, true, false, false, false, true, true, false, false }, { false, false, false, false, true, true, false, false, false, true, true, false, false, false }, { false, false, false, true, true, true, true, true, true, true, false, false, false, false }, { false, false, true, true, false, false, false, true, true, false, false, false, false, false }, { false, true, true, false, false, false, true, true, false, false, false, false, false, false }, { true, true, false, false, false, true, true, false, false, false, false, false, false, false } };
    readonly static bool[,] letterB = { { false, false, false, false, false, false, false, true, true, true, true, true, true, true }, { false, false, false, false, false, false, true, true, false, false, false, true, true, false }, { false, false, false, false, false, true, true, false, false, false, true, true, false, false }, { false, false, false, false, true, true, true, true, true, true, true, false, false, false }, { false, false, false, true, true, false, false, false, true, true, false, false, false, false }, { false, false, true, true, false, false, false, true, true, false, false, false, false, false }, { false, true, true, false, false, false, true, true, false, false, false, false, false, false }, { true, true, true, true, true, true, true, false, false, false, false, false, false, false } };
    readonly static bool[,] letterC = { { false, false, false, false, false, false, false, true, true, true, true, true, true, true }, { false, false, false, false, false, false, true, true, false, false, false, false, false, false }, { false, false, false, false, false, true, true, false, false, false, false, false, false, false }, { false, false, false, false, true, true, false, false, false, false, false, false, false, false }, { false, false, false, true, true, false, false, false, false, false, false, false, false, false }, { false, false, true, true, false, false, false, false, false, false, false, false, false, false }, { false, true, true, false, false, false, false, false, false, false, false, false, false, false }, { true, true, true, true, true, true, true, false, false, false, false, false, false, false } };
    readonly static bool[,] letterD = { { false, false, false, false, false, false, false, true, true, true, true, true, false, false }, { false, false, false, false, false, false, true, true, false, false, true, true, false, false }, { false, false, false, false, false, true, true, false, false, false, true, true, false, false }, { false, false, false, false, true, true, false, false, false, true, true, false, false, false }, { false, false, false, true, true, false, false, false, true, true, false, false, false, false }, { false, false, true, true, false, false, false, true, true, false, false, false, false, false }, { false, true, true, false, false, false, true, true, false, false, false, false, false, false }, { true, true, true, true, true, true, false, false, false, false, false, false, false, false } };
    readonly static bool[,] letterE = { { false, false, false, false, false, false, false, true, true, true, true, true, true, true }, { false, false, false, false, false, false, true, true, false, false, false, false, false, false }, { false, false, false, false, false, true, true, false, false, false, false, false, false, false }, { false, false, false, false, true, true, true, true, true, true, true, false, false, false }, { false, false, false, true, true, false, false, false, false, false, false, false, false, false }, { false, false, true, true, false, false, false, false, false, false, false, false, false, false }, { false, true, true, false, false, false, false, false, false, false, false, false, false, false }, { true, true, true, true, true, true, true, false, false, false, false, false, false, false } };
    readonly static bool[,] letterF = { { false, false, false, false, false, false, false, true, true, true, true, true, true, true }, { false, false, false, false, false, false, true, true, false, false, false, false, false, false }, { false, false, false, false, false, true, true, false, false, false, false, false, false, false }, { false, false, false, false, true, true, true, true, true, true, true, false, false, false }, { false, false, false, true, true, false, false, false, false, false, false, false, false, false }, { false, false, true, true, false, false, false, false, false, false, false, false, false, false }, { false, true, true, false, false, false, false, false, false, false, false, false, false, false }, { true, true, false, false, false, false, false, false, false, false, false, false, false, false } };
    readonly static bool[,] letterG = { { false, false, false, false, false, false, false, true, true, true, true, true, true, true }, { false, false, false, false, false, false, true, true, false, false, false, false, false, false }, { false, false, false, false, false, true, true, false, false, false, false, false, false, false }, { false, false, false, false, true, true, false, false, true, true, true, false, false, false }, { false, false, false, true, true, false, false, false, true, true, false, false, false, false }, { false, false, true, true, false, false, false, true, true, false, false, false, false, false }, { false, true, true, false, false, false, true, true, false, false, false, false, false, false }, { true, true, true, true, true, true, true, false, false, false, false, false, false, false } };
    readonly static bool[,] letterH = { { false, false, false, false, false, false, false, true, true, false, false, false, true, true }, { false, false, false, false, false, false, true, true, false, false, false, true, true, false }, { false, false, false, false, false, true, true, false, false, false, true, true, false, false }, { false, false, false, false, true, true, true, true, true, true, true, false, false, false }, { false, false, false, true, true, false, false, false, true, true, false, false, false, false }, { false, false, true, true, false, false, false, true, true, false, false, false, false, false }, { false, true, true, false, false, false, true, true, false, false, false, false, false, false }, { true, true, false, false, false, true, true, false, false, false, false, false, false, false } };
    readonly static bool[,] letterI = { { false, false, false, false, false, false, false, false, false, true, true, false, false, false }, { false, false, false, false, false, false, false, false, true, true, false, false, false, false }, { false, false, false, false, false, false, false, true, true, false, false, false, false, false }, { false, false, false, false, false, false, true, true, false, false, false, false, false, false }, { false, false, false, false, false, true, true, false, false, false, false, false, false, false }, { false, false, false, false, true, true, false, false, false, false, false, false, false, false }, { false, false, false, true, true, false, false, false, false, false, false, false, false, false }, { false, false, true, true, false, false, false, false, false, false, false, false, false, false } };
    readonly static bool[,] letterJ = { { false, false, false, false, false, false, false, false, true, true, true, true, true, true }, { false, false, false, false, false, false, false, false, false, false, false, true, true, false }, { false, false, false, false, false, false, false, false, false, false, true, true, false, false }, { false, false, false, false, false, false, false, false, false, true, true, false, false, false }, { false, false, false, false, false, false, false, false, true, true, false, false, false, false }, { false, false, false, false, false, false, false, true, true, false, false, false, false, false }, { false, false, false, false, false, false, true, true, false, false, false, false, false, false }, { false, false, true, true, true, true, true, false, false, false, false, false, false, false } };
    readonly static bool[,] letterK = { { false, false, false, false, false, false, false, true, true, false, false, false, true, true }, { false, false, false, false, false, false, true, true, false, false, true, true, false, false }, { false, false, false, false, false, true, true, false, true, true, false, false, false, false }, { false, false, false, false, true, true, true, true, false, false, false, false, false, false }, { false, false, false, true, true, true, true, false, false, false, false, false, false, false }, { false, false, true, true, false, true, true, false, false, false, false, false, false, false }, { false, true, true, false, false, true, true, false, false, false, false, false, false, false }, { true, true, false, false, false, true, true, false, false, false, false, false, false, false } };
    readonly static bool[,] letterL = { { false, false, false, false, false, false, false, true, true, false, false, false, false, false }, { false, false, false, false, false, false, true, true, false, false, false, false, false, false }, { false, false, false, false, false, true, true, false, false, false, false, false, false, false }, { false, false, false, false, true, true, false, false, false, false, false, false, false, false }, { false, false, false, true, true, false, false, false, false, false, false, false, false, false }, { false, false, true, true, false, false, false, false, false, false, false, false, false, false }, { false, true, true, false, false, false, false, false, false, false, false, false, false, false }, { true, true, true, true, true, true, true, false, false, false, false, false, false, false } };
    readonly static bool[,] letterM = { { false, false, false, false, false, false, false, true, true, false, false, false, true, true }, { false, false, false, false, false, false, true, true, true, false, true, true, true, false }, { false, false, false, false, false, true, true, true, true, true, true, true, false, false }, { false, false, false, false, true, true, false, true, false, true, true, false, false, false }, { false, false, false, true, true, false, false, false, true, true, false, false, false, false }, { false, false, true, true, false, false, false, true, true, false, false, false, false, false }, { false, true, true, false, false, false, true, true, false, false, false, false, false, false }, { true, true, false, false, false, true, true, false, false, false, false, false, false, false } };
    readonly static bool[,] letterN = { { false, false, false, false, false, false, false, true, true, false, false, true, true, false }, { false, false, false, false, false, false, true, true, false, false, true, true, false, false }, { false, false, false, false, false, true, true, false, false, true, true, false, false, false }, { false, false, false, false, true, true, false, false, true, true, false, false, false, false }, { false, false, false, true, true, false, false, true, true, false, false, false, false, false }, { false, false, true, true, true, false, true, true, false, false, false, false, false, false }, { false, true, true, false, true, true, true, false, false, false, false, false, false, false }, { true, true, false, false, true, true, false, false, false, false, false, false, false, false } };
    readonly static bool[,] letterO = { { false, false, false, false, false, false, false, true, true, true, true, true, true, true }, { false, false, false, false, false, false, true, true, false, false, false, true, true, false }, { false, false, false, false, false, true, true, false, false, false, true, true, false, false }, { false, false, false, false, true, true, false, false, false, true, true, false, false, false }, { false, false, false, true, true, false, false, false, true, true, false, false, false, false }, { false, false, true, true, false, false, false, true, true, false, false, false, false, false }, { false, true, true, false, false, false, true, true, false, false, false, false, false, false }, { true, true, true, true, true, true, true, false, false, false, false, false, false, false } };
    readonly static bool[,] letterP = { { false, false, false, false, false, false, false, true, true, true, true, true, true, true }, { false, false, false, false, false, false, true, true, false, false, false, true, true, false }, { false, false, false, false, false, true, true, false, false, false, true, true, false, false }, { false, false, false, false, true, true, true, true, true, true, true, false, false, false }, { false, false, false, true, true, false, false, false, false, false, false, false, false, false }, { false, false, true, true, false, false, false, false, false, false, false, false, false, false }, { false, true, true, false, false, false, false, false, false, false, false, false, false, false }, { true, true, false, false, false, false, false, false, false, false, false, false, false, false } };
    readonly static bool[,] letterQ = { { false, false, false, false, false, false, false, true, true, true, true, true, true, true }, { false, false, false, false, false, false, true, true, false, false, false, true, true, false }, { false, false, false, false, false, true, true, false, false, false, true, true, false, false }, { false, false, false, false, true, true, false, false, false, true, true, false, false, false }, { false, false, false, true, true, false, true, false, true, true, false, false, false, false }, { false, false, true, true, false, true, true, true, true, false, false, false, false, false }, { false, true, true, false, false, true, true, true, false, false, false, false, false, false }, { true, true, true, true, true, true, true, false, false, false, false, false, false, false } };
    readonly static bool[,] letterR = { { false, false, false, false, false, false, false, true, true, true, true, true, true, true }, { false, false, false, false, false, false, true, true, false, false, false, true, true, false }, { false, false, false, false, false, true, true, false, false, false, true, true, false, false }, { false, false, false, false, true, true, true, true, true, true, true, false, false, false }, { false, false, false, true, true, true, true, false, false, false, false, false, false, false }, { false, false, true, true, false, true, true, false, false, false, false, false, false, false }, { false, true, true, false, false, true, true, false, false, false, false, false, false, false }, { true, true, false, false, false, true, true, false, false, false, false, false, false, false } };
    readonly static bool[,] letterS = { { false, false, false, false, false, false, false, true, true, true, true, true, true, true }, { false, false, false, false, false, false, true, true, false, false, false, false, false, false }, { false, false, false, false, false, true, true, false, false, false, false, false, false, false }, { false, false, false, false, true, true, true, true, true, true, true, false, false, false }, { false, false, false, false, false, false, false, false, true, true, false, false, false, false }, { false, false, false, false, false, false, false, true, true, false, false, false, false, false }, { false, false, false, false, false, false, true, true, false, false, false, false, false, false }, { true, true, true, true, true, true, true, false, false, false, false, false, false, false } };
    readonly static bool[,] letterT = { { false, false, false, false, false, false, true, true, true, true, true, true, true, true }, { false, false, false, false, false, false, false, false, true, true, false, false, false, false }, { false, false, false, false, false, false, false, true, true, false, false, false, false, false }, { false, false, false, false, false, false, true, true, false, false, false, false, false, false }, { false, false, false, false, false, true, true, false, false, false, false, false, false, false }, { false, false, false, false, true, true, false, false, false, false, false, false, false, false }, { false, false, false, true, true, false, false, false, false, false, false, false, false, false }, { false, false, true, true, false, false, false, false, false, false, false, false, false, false } };
    readonly static bool[,] letterU = { { false, false, false, false, false, false, false, true, true, false, false, false, true, true }, { false, false, false, false, false, false, true, true, false, false, false, true, true, false }, { false, false, false, false, false, true, true, false, false, false, true, true, false, false }, { false, false, false, false, true, true, false, false, false, true, true, false, false, false }, { false, false, false, true, true, false, false, false, true, true, false, false, false, false }, { false, false, true, true, false, false, false, true, true, false, false, false, false, false }, { false, true, true, false, false, false, true, true, false, false, false, false, false, false }, { true, true, true, true, true, true, true, false, false, false, false, false, false, false } };
    readonly static bool[,] letterV = { { false, false, false, false, false, false, false, true, true, false, false, false, true, true }, { false, false, false, false, false, false, true, true, false, false, false, true, true, false }, { false, false, false, false, false, true, true, false, false, false, true, true, false, false }, { false, false, false, false, true, true, false, false, false, true, true, false, false, false }, { false, false, false, true, true, false, false, false, true, true, false, false, false, false }, { false, false, false, true, true, false, true, true, false, false, false, false, false, false }, { false, false, true, true, false, true, true, false, false, false, false, false, false, false }, { false, false, true, true, true, false, false, false, false, false, false, false, false, false } };
    readonly static bool[,] letterW = { { false, false, false, false, false, false, false, true, true, false, false, false, true, true }, { false, false, false, false, false, false, true, true, false, false, false, true, true, false }, { false, false, false, false, false, true, true, false, false, false, true, true, false, false }, { false, false, false, false, true, true, false, true, false, true, true, false, false, false }, { false, false, false, true, true, false, true, false, true, true, false, false, false, false }, { false, false, true, true, false, true, false, true, true, false, false, false, false, false }, { false, true, true, false, true, false, true, true, false, false, false, false, false, false }, { true, true, true, true, true, true, true, false, false, false, false, false, false, false } };
    readonly static bool[,] letterX = { { false, false, false, false, false, false, false, true, true, false, false, false, true, true }, { false, false, false, false, false, false, true, true, false, false, false, true, true, false }, { false, false, false, false, false, false, true, true, false, true, true, false, false, false }, { false, false, false, false, false, false, true, true, true, false, false, false, false, false }, { false, false, false, false, true, true, false, true, true, false, false, false, false, false }, { false, false, true, true, false, false, false, true, true, false, false, false, false, false }, { false, true, true, false, false, false, true, true, false, false, false, false, false, false }, { true, true, false, false, false, true, true, false, false, false, false, false, false, false } };
    readonly static bool[,] letterY = { { false, false, false, false, false, false, true, true, false, false, false, false, true, true }, { false, false, false, false, false, true, true, false, false, false, false, true, true, false }, { false, false, false, false, false, true, true, false, false, true, true, false, false, false }, { false, false, false, false, false, true, true, true, true, false, false, false, false, false }, { false, false, false, false, false, true, true, false, false, false, false, false, false, false }, { false, false, false, false, true, true, false, false, false, false, false, false, false, false }, { false, false, false, true, true, false, false, false, false, false, false, false, false, false }, { false, false, true, true, false, false, false, false, false, false, false, false, false, false } };
    readonly static bool[,] letterZ = { { false, false, false, false, false, false, false, true, true, true, true, true, true, true }, { false, false, false, false, false, false, false, false, false, false, false, true, true, false }, { false, false, false, false, false, false, false, false, false, true, true, false, false, false }, { false, false, false, false, false, false, false, true, true, false, false, false, false, false }, { false, false, false, false, false, true, true, false, false, false, false, false, false, false }, { false, false, false, true, true, false, false, false, false, false, false, false, false, false }, { false, true, true, false, false, false, false, false, false, false, false, false, false, false }, { true, true, true, true, true, true, true, false, false, false, false, false, false, false } };
    readonly static bool[,] letterASmall = { { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, true, true, true, true, true, false, false, false, false, false }, { false, false, false, true, true, false, true, true, false, false, false, false, false, false }, { false, false, true, true, true, true, true, false, false, false, false, false, false, false }, { false, true, true, false, true, true, false, false, false, false, false, false, false, false }, { true, true, false, true, true, false, false, false, false, false, false, false, false, false } };
    readonly static bool[,] letterBSmall = { { false, false, false, false, false, false, false, true, true, false, false, false, false, false }, { false, false, false, false, false, false, true, true, false, false, false, false, false, false }, { false, false, false, false, false, true, true, false, false, false, false, false, false, false }, { false, false, false, false, true, true, true, true, true, false, false, false, false, false }, { false, false, false, true, true, false, true, true, false, false, false, false, false, false }, { false, false, true, true, false, true, true, false, false, false, false, false, false, false }, { false, true, true, false, true, true, false, false, false, false, false, false, false, false }, { true, true, true, true, true, false, false, false, false, false, false, false, false, false } };
    readonly static bool[,] letterCSmall = { { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, true, true, true, true, true, false, false, false, false, false }, { false, false, false, true, true, false, false, false, false, false, false, false, false, false }, { false, false, true, true, false, false, false, false, false, false, false, false, false, false }, { false, true, true, false, false, false, false, false, false, false, false, false, false, false }, { true, true, true, true, true, false, false, false, false, false, false, false, false, false } };
    readonly static bool[,] letterDSmall = { { false, false, false, false, false, false, false, false, false, false, true, true, false, false }, { false, false, false, false, false, false, false, false, false, true, true, false, false, false }, { false, false, false, false, false, false, false, false, true, true, false, false, false, false }, { false, false, false, false, true, true, true, true, true, false, false, false, false, false }, { false, false, false, true, true, false, true, true, false, false, false, false, false, false }, { false, false, true, true, false, true, true, false, false, false, false, false, false, false }, { false, true, true, false, true, true, false, false, false, false, false, false, false, false }, { true, true, true, true, true, false, false, false, false, false, false, false, false, false } };
    readonly static bool[,] letterESmall = { { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, true, true, true, true, true, false, false, false, false, false }, { false, false, false, true, true, false, false, false, false, false, false, false, false, false }, { false, false, true, true, true, true, true, false, false, false, false, false, false, false }, { false, true, true, false, false, false, false, false, false, false, false, false, false, false }, { true, true, true, true, true, false, false, false, false, false, false, false, false, false } };
    readonly static bool[,] letterFSmall = { { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, true, true, true, true, true, false, false, false, false }, { false, false, false, false, true, true, false, false, false, false, false, false, false, false }, { false, false, false, true, true, true, true, false, false, false, false, false, false, false }, { false, false, true, true, false, false, false, false, false, false, false, false, false, false }, { false, true, true, false, false, false, false, false, false, false, false, false, false, false }, { true, true, false, false, false, false, false, false, false, false, false, false, false, false } };
    readonly static bool[,] letterGSmall = { { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, true, true, true, true, true, false, false, false, false, false }, { false, false, false, true, true, false, true, true, false, false, false, false, false, false }, { false, false, true, true, false, true, true, false, false, false, false, false, false, false }, { false, true, true, false, true, true, false, false, false, false, false, false, false, false }, { true, true, true, true, true, false, false, false, false, false, false, false, false, false } };
    readonly static bool[,] letterHSmall = { { false, false, false, false, false, false, false, true, true, false, false, false, false, false }, { false, false, false, false, false, false, true, true, false, false, false, false, false, false }, { false, false, false, false, false, true, true, false, false, false, false, false, false, false }, { false, false, false, false, true, true, true, true, true, false, false, false, false, false }, { false, false, false, true, true, false, true, true, false, false, false, false, false, false }, { false, false, true, true, false, true, true, false, false, false, false, false, false, false }, { false, true, true, false, true, true, false, false, false, false, false, false, false, false }, { true, true, false, true, true, false, false, false, false, false, false, false, false, false } };
    readonly static bool[,] letterISmall = { { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, true, true, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, true, true, false, false, false, false, false, false, false, false }, { false, false, false, true, true, false, false, false, false, false, false, false, false, false }, { false, false, true, true, false, false, false, false, false, false, false, false, false, false }, { false, true, true, false, false, false, false, false, false, false, false, false, false, false }, { true, true, false, false, false, false, false, false, false, false, false, false, false, false } };
    readonly static bool[,] letterJSmall = { { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, true, true, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, true, true, false, false, false, false, false, false, false }, { false, false, false, false, true, true, false, false, false, false, false, false, false, false }, { false, false, false, true, true, false, false, false, false, false, false, false, false, false }, { false, false, true, true, false, false, false, false, false, false, false, false, false, false }, { false, true, true, false, false, false, false, false, false, false, false, false, false, false } };
    readonly static bool[,] letterLSmall = { { false, false, false, false, false, false, false, true, true, false, false, false, false, false }, { false, false, false, false, false, false, true, true, false, false, false, false, false, false }, { false, false, false, false, false, true, true, false, false, false, false, false, false, false }, { false, false, false, false, true, true, false, false, false, false, false, false, false, false }, { false, false, false, true, true, false, false, false, false, false, false, false, false, false }, { false, false, true, true, false, false, false, false, false, false, false, false, false, false }, { false, true, true, false, false, false, false, false, false, false, false, false, false, false }, { true, true, true, false, false, false, false, false, false, false, false, false, false, false } };
    readonly static bool[,] letterKSmall = { { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, true, true, false, false, true, true, false, false, false, false }, { false, false, false, true, true, false, true, true, false, false, false, false, false, false }, { false, false, true, true, true, true, false, false, false, false, false, false, false, false }, { false, true, true, false, true, true, false, false, false, false, false, false, false, false }, { true, true, false, false, false, true, true, false, false, false, false, false, false, false } };
    readonly static bool[,] letterMSmall = { { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, true, true, true, true, true, true, true, false, false, false }, { false, false, false, true, true, false, true, false, true, true, false, false, false, false }, { false, false, true, true, false, true, false, true, true, false, false, false, false, false }, { false, true, true, false, true, false, true, true, false, false, false, false, false, false }, { true, true, false, true, false, true, true, false, false, false, false, false, false, false } };
    readonly static bool[,] letterNSmall = { { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, true, true, true, true, true, false, false, false, false, false }, { false, false, false, true, true, false, true, true, false, false, false, false, false, false }, { false, false, true, true, false, true, true, false, false, false, false, false, false, false }, { false, true, true, false, true, true, false, false, false, false, false, false, false, false }, { true, true, false, true, true, false, false, false, false, false, false, false, false, false } };
    readonly static bool[,] letterOSmall = { { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, true, true, true, true, true, false, false, false, false, false }, { false, false, false, true, true, false, true, true, false, false, false, false, false, false }, { false, false, true, true, false, true, true, false, false, false, false, false, false, false }, { false, true, true, false, true, true, false, false, false, false, false, false, false, false }, { true, true, true, true, true, false, false, false, false, false, false, false, false, false } };
    readonly static bool[,] letterPSmall = { { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, true, true, true, true, true, false, false, false, false, false }, { false, false, false, true, true, false, true, true, false, false, false, false, false, false }, { false, false, true, true, true, true, true, false, false, false, false, false, false, false }, { false, true, true, false, false, false, false, false, false, false, false, false, false, false }, { true, true, false, false, false, false, false, false, false, false, false, false, false, false } };
    readonly static bool[,] letterQSmall = { { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, true, true, true, true, true, false, false, false, false, false }, { false, false, false, true, true, false, true, true, false, false, false, false, false, false }, { false, false, true, true, false, true, true, false, false, false, false, false, false, false }, { false, true, true, false, true, true, false, false, false, false, false, false, false, false }, { true, true, true, true, true, false, false, false, false, false, false, false, false, false } };
    readonly static bool[,] letterRSmall = { { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, true, true, true, true, true, false, false, false, false, false }, { false, false, false, true, true, false, false, false, false, false, false, false, false, false }, { false, false, true, true, false, false, false, false, false, false, false, false, false, false }, { false, true, true, false, false, false, false, false, false, false, false, false, false, false }, { true, true, false, false, false, false, false, false, false, false, false, false, false, false } };
    readonly static bool[,] letterSSmall = { { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, true, true, true, true, true, false, false, false, false, false }, { false, false, false, true, true, false, false, false, false, false, false, false, false, false }, { false, false, true, true, true, true, true, false, false, false, false, false, false, false }, { false, false, false, false, true, true, false, false, false, false, false, false, false, false }, { true, true, true, true, true, false, false, false, false, false, false, false, false, false } };
    readonly static bool[,] letterTSmall = { { false, false, false, false, false, false, false, true, true, false, false, false, false, false }, { false, false, false, false, false, false, true, true, true, true, false, false, false, false }, { false, false, false, false, false, true, true, false, false, false, false, false, false, false }, { false, false, false, false, true, true, false, false, false, false, false, false, false, false }, { false, false, false, true, true, false, false, false, false, false, false, false, false, false }, { false, false, true, true, false, false, false, false, false, false, false, false, false, false }, { false, true, true, false, false, false, false, false, false, false, false, false, false, false }, { true, true, true, true, true, false, false, false, false, false, false, false, false, false } };
    readonly static bool[,] letterUSmall = { { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, true, true, false, true, true, false, false, false, false, false }, { false, false, false, true, true, false, true, true, false, false, false, false, false, false }, { false, false, true, true, false, true, true, false, false, false, false, false, false, false }, { false, true, true, false, true, true, false, false, false, false, false, false, false, false }, { true, true, true, true, true, false, false, false, false, false, false, false, false, false } };
    readonly static bool[,] letterVSmall = { { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, true, true, false, true, true, false, false, false, false, false }, { false, false, false, true, true, false, true, true, false, false, false, false, false, false }, { false, false, true, true, false, true, true, false, false, false, false, false, false, false }, { false, false, true, true, true, false, false, false, false, false, false, false, false, false }, { false, false, true, true, false, false, false, false, false, false, false, false, false, false } };
    readonly static bool[,] letterWSmall = { { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, true, true, false, true, false, true, true, false, false, false }, { false, false, false, true, true, false, true, false, true, true, false, false, false, false }, { false, false, true, true, false, true, false, true, true, false, false, false, false, false }, { false, true, true, false, true, false, true, true, false, false, false, false, false, false }, { true, true, true, true, true, true, true, false, false, false, false, false, false, false } };
    readonly static bool[,] letterXSmall = { { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, true, true, false, true, true, false, false, false, false, false, false, false }, { false, false, true, true, false, true, true, false, false, false, false, false, false, false }, { false, false, false, true, true, false, false, false, false, false, false, false, false, false }, { false, false, true, true, false, true, true, false, false, false, false, false, false, false }, { false, true, true, false, false, true, true, false, false, false, false, false, false, false } };
    readonly static bool[,] letterYSmall = { { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, true, true, false, true, true, false, false, false, false, false }, { false, false, false, true, true, false, true, true, false, false, false, false, false, false }, { false, false, true, true, false, true, true, false, false, false, false, false, false, false }, { false, true, true, false, true, true, false, false, false, false, false, false, false, false }, { true, true, true, true, true, false, false, false, false, false, false, false, false, false } };
    readonly static bool[,] letterZSmall = { { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { true, true, true, true, true, true, false, false, false, false, false, false, false, false }, { false, false, false, true, true, false, false, false, false, false, false, false, false, false }, { false, false, true, true, false, false, false, false, false, false, false, false, false, false }, { false, true, true, false, false, false, false, false, false, false, false, false, false, false }, { true, true, true, true, true, true, false, false, false, false, false, false, false, false } };
    readonly static bool[,] interval = { { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false } };

    readonly static Dictionary<char, bool[,]> letters = new Dictionary<char, bool[,]>()
    {
        {'A',letterA}, {'B',letterB}, {'C',letterC}, {'D',letterD}, {'E',letterE}, {'F',letterF}, {'G',letterG}, 
        {'H',letterH}, {'I',letterI}, {'J',letterJ}, {'K',letterK}, {'L',letterL}, {'M',letterM}, {'N',letterN}, 
        {'O',letterO}, {'P',letterP}, {'Q',letterQ}, {'R',letterR}, {'S',letterS}, {'T',letterT}, {'U',letterU}, 
        {'V',letterV}, {'W',letterW}, {'X',letterX}, {'Y',letterY}, {'Z',letterZ}, 
        {'a',letterASmall}, {'b',letterBSmall}, {'c',letterCSmall}, {'d',letterDSmall}, {'e',letterESmall}, 
        {'f',letterFSmall}, {'g',letterGSmall}, {'h',letterHSmall}, {'i',letterISmall}, {'j',letterJSmall},
        {'k',letterKSmall}, {'l',letterLSmall}, {'m',letterMSmall}, {'n',letterNSmall}, {'o',letterOSmall},
        {'p',letterPSmall},{'q',letterQSmall}, {'r',letterRSmall}, {'s',letterSSmall}, {'t',letterTSmall}, 
        {'u',letterUSmall}, {'v',letterVSmall}, {'w',letterWSmall}, {'x',letterXSmall}, {'y',letterYSmall},
        {'z',letterZSmall},{' ',interval},
    };

    //Draws screen headers
    public static void DrawHeader(string line1, string line2, ConsoleColor color, int row1X, int row1Y, int row2X, int row2Y)
    {
        bool[,] toColor = new bool[Console.WindowHeight, Console.WindowWidth];
        HeaderLine(row1X, row1Y, line1, toColor);
        HeaderLine(row2X, row2Y, line2, toColor);

        StringBuilder screenBuilder = new StringBuilder();

        for (int i = 0; i < toColor.GetLength(0); i++)
        {
            for (int j = 0; j < toColor.GetLength(1); j++)
            {
                screenBuilder.Append(' ');
                if (toColor[i, j] && !toColor[i, j + 1])
                {
                    Console.BackgroundColor = color;
                    Console.Write(screenBuilder.ToString());
                    Console.BackgroundColor = ConsoleColor.Black;
                    screenBuilder.Clear();
                }
                else if (j == (toColor.GetLength(1) - 1) || (!toColor[i, j] && toColor[i, j + 1]))
                {
                    Console.Write(screenBuilder.ToString());
                    screenBuilder.Clear();
                }
            }
        }
    }

    //Adds to the array used to draw screen headers,a specific line of text
    private static void HeaderLine(int xOffset, int yOffset, string text, bool[,] toColor)
    {
        bool afterCapital = false;
        foreach (char item in text)
        {
            if (letters.ContainsKey(item))
            {
                if (item != ' ')
                {
                    bool[,] temp = letters[item];
                    if (afterCapital)
                    {
                        if (item >= 'A' && item <= 'Z')
                        {
                            xOffset += 1;
                        }
                        else
                        {
                            xOffset += 2;
                        }

                    }

                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 14; j++)
                        {
                            toColor[i + yOffset, j + xOffset] = toColor[i + yOffset, j + xOffset] || temp[i, j];
                        }
                    }

                    switch (item)
                    {
                        case 'g':
                            toColor[yOffset + 8, xOffset + 2] = true;
                            toColor[yOffset + 8, xOffset + 3] = true;
                            toColor[yOffset + 9, xOffset - 2] = true;
                            toColor[yOffset + 9, xOffset - 1] = true;
                            toColor[yOffset + 9, xOffset + 1] = true;
                            toColor[yOffset + 9, xOffset + 2] = true;
                            toColor[yOffset + 10, xOffset - 3] = true;
                            toColor[yOffset + 10, xOffset - 2] = true;
                            toColor[yOffset + 10, xOffset - 1] = true;
                            toColor[yOffset + 10, xOffset] = true;
                            toColor[yOffset + 10, xOffset + 1] = true;
                            xOffset += 6;
                            break;
                        case 'i':
                            xOffset += 3;
                            break;
                        case 'l':
                            xOffset += 4;
                            break;
                        case 'j':
                            toColor[yOffset + 8, xOffset] = true;
                            toColor[yOffset + 8, xOffset + 1] = true;
                            toColor[yOffset + 9, xOffset - 2] = true;
                            toColor[yOffset + 9, xOffset - 1] = true;
                            toColor[yOffset + 9, xOffset] = true;
                            xOffset += 4;
                            break;
                        case 'k':
                            xOffset += 8;
                            break;
                        case 'q':
                            toColor[yOffset + 8, xOffset + 4] = true;
                            toColor[yOffset + 8, xOffset + 5] = true;
                            xOffset += 6;
                            break;
                        case 'm': 
                            xOffset += 8;
                            break;
                        case 'w':
                            xOffset += 8;
                            break;
                        case 'y':
                            toColor[yOffset + 8, xOffset + 2] = true;
                            toColor[yOffset + 8, xOffset + 3] = true;
                            toColor[yOffset + 9, xOffset - 2] = true;
                            toColor[yOffset + 9, xOffset - 1] = true;
                            toColor[yOffset + 9, xOffset] = true;
                            toColor[yOffset + 9, xOffset + 1] = true;
                            toColor[yOffset + 9, xOffset + 2] = true;
                            xOffset += 6;
                            break;
                        case 'x':
                            xOffset += 8;
                            break;
                        default: xOffset += 6; break;
                    }


                    if (item >= 'A' && item <= 'Z')
                    {
                        afterCapital = true;
                    }
                    else
                    {
                        afterCapital = false;
                    }
                }
                else
                {
                    xOffset += 5;
                }
            }
        }
    }

    public static void DrawGame(GameElement player, List<GameElement> playerProjectiles, List<GameElement> enemies, List<GameElement> enemyProjectiles, GameStatus currentStatus)
    {
        Console.Clear();
        DrawPlayer(player);
        DrawPlayerProjectiles(playerProjectiles);
        foreach (GameElement item in enemies)
        {
            DrawEnemies(item);
        }
        DrawEnemyProjectiles(enemyProjectiles);
        DrawHud(currentStatus);
    }

    public static void DrawPlayer(GameElement player)
    {
        if ((int)player.ElementState == (int)Altitude.Mid)
        {
            if (player.StepState)
            {
                Console.ForegroundColor = GameElement.PlayerColor;
                Console.SetCursorPosition(player.Coordinate, Console.WindowHeight - 6);
                Console.WriteLine(" O ");
                Console.SetCursorPosition(player.Coordinate, Console.WindowHeight - 5);
                Console.WriteLine(@"/|\");
                Console.SetCursorPosition(player.Coordinate, Console.WindowHeight - 4);
                Console.WriteLine(@"/ \");
            }
            else
            {
                Console.ForegroundColor = GameElement.PlayerColor;
                Console.SetCursorPosition(player.Coordinate, Console.WindowHeight - 6);
                Console.WriteLine(" O ");
                Console.SetCursorPosition(player.Coordinate, Console.WindowHeight - 5);
                Console.WriteLine(@"/|\");
                Console.SetCursorPosition(player.Coordinate, Console.WindowHeight - 4);
                Console.WriteLine(@" | ");
            }
        }
        else if ((int)player.ElementState == (int)Altitude.High)
        {
            Console.ForegroundColor = GameElement.PlayerColor;
            Console.SetCursorPosition(player.Coordinate, Console.WindowHeight - 7);
            Console.WriteLine(@"\O/");
            Console.SetCursorPosition(player.Coordinate, Console.WindowHeight - 6);
            Console.WriteLine("_|_");
        }
        else
        {
            Console.ForegroundColor = GameElement.PlayerColor;
            Console.SetCursorPosition(player.Coordinate - 1, Console.WindowHeight - 5);
            Console.WriteLine("_O_");
            Console.SetCursorPosition(player.Coordinate - 1, Console.WindowHeight - 4);
            Console.WriteLine(@"  _\");
        }
    }

    public static void DrawEnemiesSnakes(GameElement enemySnake)
    {
        if (enemySnake.StepState)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(enemySnake.Coordinate, Console.WindowHeight - 4);
            Console.WriteLine("0____/");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(enemySnake.Coordinate, Console.WindowHeight - 4);
            Console.WriteLine(@"0_/\_|");
        }
    }

    public static void DrawEnemiesNinjas(GameElement enemyNinja)
    {
        if (enemyNinja.StepState)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(enemyNinja.Coordinate, Console.WindowHeight - 6);
            Console.WriteLine("0~");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(enemyNinja.Coordinate, Console.WindowHeight - 5);
            Console.WriteLine(@"-\-");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(enemyNinja.Coordinate, Console.WindowHeight - 4);
            Console.WriteLine(@" /\");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(enemyNinja.Coordinate, Console.WindowHeight - 6);
            Console.WriteLine("0~");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(enemyNinja.Coordinate, Console.WindowHeight - 5);
            Console.WriteLine(@"-\-");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(enemyNinja.Coordinate, Console.WindowHeight - 4);
            Console.WriteLine(@" ||");
        }
    }

    public static void DrawEnemiesDogs(GameElement enemyDog)
    {
        if (enemyDog.StepState)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(enemyDog.Coordinate, Console.WindowHeight - 5);
            Console.WriteLine("d____/");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(enemyDog.Coordinate, Console.WindowHeight - 4);
            Console.WriteLine(@" /\ /\");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(enemyDog.Coordinate, Console.WindowHeight - 5);
            Console.WriteLine("d_____");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(enemyDog.Coordinate, Console.WindowHeight - 4);
            Console.WriteLine("  | |");
        }
    }

    public static void DrawEnemiesBats(GameElement enemyBat)
    {
        if (enemyBat.StepState)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(enemyBat.Coordinate, Console.WindowHeight - 8);
            Console.WriteLine("_   _");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(enemyBat.Coordinate, Console.WindowHeight - 7);
            Console.WriteLine(@" \ / ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(enemyBat.Coordinate, Console.WindowHeight - 6);
            Console.WriteLine(@"  O  ");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(enemyBat.Coordinate, Console.WindowHeight - 7);
            Console.WriteLine(@"/\ /\");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(enemyBat.Coordinate, Console.WindowHeight - 6);
            Console.WriteLine(@"  O  ");
        }
    }

    public static void DrawEnemiesShooter(GameElement enemy)
    {
        if ((int)enemy.ElementState == (int)Altitude.Mid)
        {
            if (enemy.StepState)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.SetCursorPosition(enemy.Coordinate, Console.WindowHeight - 6);
                Console.WriteLine("   o ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.SetCursorPosition(enemy.Coordinate, Console.WindowHeight - 5);
                Console.WriteLine("---|>");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.SetCursorPosition(enemy.Coordinate, Console.WindowHeight - 4);
                Console.WriteLine("   | ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.SetCursorPosition(enemy.Coordinate, Console.WindowHeight - 6);
                Console.WriteLine("   o ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.SetCursorPosition(enemy.Coordinate, Console.WindowHeight - 5);
                Console.WriteLine("---|>");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.SetCursorPosition(enemy.Coordinate, Console.WindowHeight - 4);
                Console.WriteLine(@"  / \");
            }
        }
        else if ((int)enemy.ElementState == (int)Altitude.High)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(enemy.Coordinate, Console.WindowHeight - 8);
            Console.WriteLine(@"___o/");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(enemy.Coordinate, Console.WindowHeight - 7);
            Console.WriteLine("   _|_");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(enemy.Coordinate - 1, Console.WindowHeight - 5);
            Console.WriteLine(" ___o_");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(enemy.Coordinate - 1, Console.WindowHeight - 4);
            Console.WriteLine(@"   /_");
        }
    }

    public static void DrawEnemies(GameElement enemy)
    {
        switch (enemy.Type)
        {
            case ElementType.EnemySnake: DrawEnemiesSnakes(enemy); break;
            case ElementType.EnemyNinja: DrawEnemiesNinjas(enemy); break;
            case ElementType.EnemyDog: DrawEnemiesDogs(enemy); break;
            case ElementType.EnemyBat: DrawEnemiesBats(enemy); break;
            case ElementType.EnemyShooter: DrawEnemiesShooter(enemy); break;
        }
    }

    public static void DrawPlayerProjectiles(List<GameElement> playerProjectiles)
    {
        Console.ForegroundColor = GameElement.PlayerColor;

        foreach (GameElement projectiles in playerProjectiles)
        {
            if (projectiles.ElementState == Altitude.High)
            {
                Console.SetCursorPosition(projectiles.Coordinate + 1, Console.WindowHeight - 6);
                Console.WriteLine(GameElement.ProjectileShape);
            }
            else if (projectiles.ElementState == Altitude.Low)
            {
                Console.SetCursorPosition(projectiles.Coordinate + 1, Console.WindowHeight - 4);
                Console.WriteLine(GameElement.ProjectileShape);
            }
            else
            {
                Console.SetCursorPosition(projectiles.Coordinate + 1, Console.WindowHeight - 5);
                Console.WriteLine(GameElement.ProjectileShape);
            }
        }
    }

    public static void DrawEnemyProjectiles(List<GameElement> enemyProjectiles)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;

        foreach (GameElement projectiles in enemyProjectiles)
        {
            if (projectiles.ElementState == Altitude.High)
            {
                Console.SetCursorPosition(projectiles.Coordinate, Console.WindowHeight - 6);
                Console.WriteLine(GameElement.ProjectileShape);
            }
            else if (projectiles.ElementState == Altitude.Low)
            {
                Console.SetCursorPosition(projectiles.Coordinate, Console.WindowHeight - 4);
                Console.WriteLine(GameElement.ProjectileShape);
            }
            else
            {
                Console.SetCursorPosition(projectiles.Coordinate, Console.WindowHeight - 5);
                Console.WriteLine(GameElement.ProjectileShape);
            }
        }
    }

    public static void DrawHud(GameStatus currentStatus)
    {
        Console.SetCursorPosition(60, 2);
        Console.ForegroundColor = ConsoleColor.White;
        DrawScreen.InGameStats(currentStatus.Level, currentStatus.Lives, currentStatus.Score);
    }

    public static void Start()
    {
        Console.SetCursorPosition(0, 0);
        DrawHeader("Just", "Ninja", ConsoleColor.DarkCyan, 15, 3, 4, 14);
        
        
    }

    public static byte StartinScreenInteraction(ConsoleKeyInfo keyInfo, byte cursorPosition)
    {
        if (keyInfo.Key == ConsoleKey.DownArrow)
        {
            cursorPosition++;
            if (cursorPosition > 6)
            {
                cursorPosition = 1;
            }
        }
        else if (keyInfo.Key == ConsoleKey.UpArrow)
        {
            cursorPosition--;
            if (cursorPosition < 1)
            {
                cursorPosition = 6;
            }
        }

        switch (cursorPosition)
        {
            case 1:
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(50, 12);
                Console.WriteLine(" NEW GAME      ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(50, 14);
                Console.WriteLine("High scores    ");
                Console.SetCursorPosition(50, 16);
                Console.WriteLine("How to play    ");
                Console.SetCursorPosition(50, 18);
                Console.WriteLine("Settings       ");
                Console.SetCursorPosition(50, 20);
                Console.WriteLine("Credits        ");
                Console.SetCursorPosition(50, 22);
                Console.WriteLine("Exit           ");
                break;
            case 2:
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(50, 12);
                Console.WriteLine("New game       ");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(50, 14);
                Console.WriteLine(" HIGH SCORES   ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(50, 16);
                Console.WriteLine("How to play    ");
                Console.SetCursorPosition(50, 18);
                Console.WriteLine("Settings       ");
                Console.SetCursorPosition(50, 20);
                Console.WriteLine("Credits        ");
                Console.SetCursorPosition(50, 22);
                Console.WriteLine("Exit           ");
                break;
            case 3:
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(50, 12);
                Console.WriteLine("New game       ");
                Console.SetCursorPosition(50, 14);
                Console.WriteLine("High scores    ");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(50, 16);
                Console.WriteLine(" HOW TO PLAY   ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(50, 18);
                Console.WriteLine("Settings       ");
                Console.SetCursorPosition(50, 20);
                Console.WriteLine("Credits        ");
                Console.SetCursorPosition(50, 22);
                Console.WriteLine("Exit           ");
                break;
            case 4:
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(50, 12);
                Console.WriteLine("New game       ");
                Console.SetCursorPosition(50, 14);
                Console.WriteLine("High scores    ");
                Console.SetCursorPosition(50, 16);
                Console.WriteLine("How to play    ");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(50, 18);
                Console.WriteLine(" SETTINGS      ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(50, 20);
                Console.WriteLine("Credits        ");
                Console.SetCursorPosition(50, 22);
                Console.WriteLine("Exit           ");
                break;
            case 5:
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(50, 12);
                Console.WriteLine("New game       ");
                Console.SetCursorPosition(50, 14);
                Console.WriteLine("High scores    ");
                Console.SetCursorPosition(50, 16);
                Console.WriteLine("How to play    ");
                Console.SetCursorPosition(50, 18);
                Console.WriteLine("Settings       ");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(50, 20);
                Console.WriteLine(" CREDITS       ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(50, 22);
                Console.WriteLine("Exit           ");
                break;
            case 6:
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(50, 12);
                Console.WriteLine("New game       ");
                Console.SetCursorPosition(50, 14);
                Console.WriteLine("High scores    ");
                Console.SetCursorPosition(50, 16);
                Console.WriteLine("How to play    ");
                Console.SetCursorPosition(50, 18);
                Console.WriteLine("Settings       ");
                Console.SetCursorPosition(50, 20);
                Console.WriteLine("Credits        ");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(50, 22);
                Console.WriteLine(" EXIT          ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                break;
        }

        return cursorPosition;
    }

    public static void HighScoreScreen()
    {
        Console.SetCursorPosition(0, 0);
        DrawHeader("High", "Scores", ConsoleColor.DarkGray, 15, 3, 4, 14);
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.SetCursorPosition(47, 5);
        Console.WriteLine("┌───┬──────────┬─────────────┐");
        Console.SetCursorPosition(47, 6);
        Console.WriteLine("│ N │   NAME   │    SCORE    │");
        Console.SetCursorPosition(47, 7);
        Console.WriteLine("├───┼──────────┼─────────────┤");

        try
        {
            using (StreamReader highScores = new StreamReader(@"..\..\HighScores.txt"))
            {
                byte position = 1;

                for (string line = highScores.ReadLine(); line != null; line = highScores.ReadLine())
                {
                    string[] scoreEntry = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    Console.SetCursorPosition(47, (7 + position));
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write('│');
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(position.ToString().PadLeft(2).PadRight(3));
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write('│');
                    Console.ForegroundColor = ConsoleColor.White;

                    if (scoreEntry[0].Length <= 8)
                    {
                        Console.Write(" " + scoreEntry[0].PadRight(9));
                    }
                    else
                    {
                        Console.Write(" " + scoreEntry[0].Substring(0, 8).PadRight(9));
                    }

                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write('│');
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(scoreEntry[1].PadLeft(12) + " ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write('│');
                    position++;
                }
            }

            Console.SetCursorPosition(47, 18);
            Console.WriteLine("└───┴──────────┴─────────────┘");
            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.SetCursorPosition(50, 22);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(" BACK          ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.Clear();
            string message = e.Message;
            Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, Console.WindowHeight / 2);
            Console.WriteLine(message);
        }
        catch (ArgumentNullException e)
        {
            Console.Clear();
            string message = e.Message;
            Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, Console.WindowHeight / 2);
            Console.WriteLine(message);
        }
        catch (ArgumentException e)
        {
            Console.Clear();
            string message = e.Message;
            Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, Console.WindowHeight / 2);
            Console.WriteLine(message);
        }
        catch (FileNotFoundException e)
        {
            Console.Clear();
            string message = e.Message;
            Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, Console.WindowHeight / 2);
            Console.WriteLine(message);
        }
        catch (DirectoryNotFoundException e)
        {
            Console.Clear();
            string message = e.Message;
            Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, Console.WindowHeight / 2);
            Console.WriteLine(message);
        }
        catch (IOException e)
        {
            Console.Clear();
            string message = e.Message;
            Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, Console.WindowHeight / 2);
            Console.WriteLine(message);
        }
        catch (OverflowException e)
        {
            Console.Clear();
            string message = e.Message;
            Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, Console.WindowHeight / 2);
            Console.WriteLine(message);
        }
    }

    public static void HowToPlayScreen()
    {
        Console.SetCursorPosition(0, 0);
        DrawHeader("How to", "Play", ConsoleColor.DarkRed, 15, 3, 4, 14);

        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(45, 14);
        Console.Write("UP arrow - ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Jump");
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(45, 16);
        Console.Write("DOWN arrow - ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Crouch");
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(45, 18);
        Console.Write("SPACEBAR - ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Shoot");
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(45, 20);
        Console.Write("ESCAPE - ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Pause");
        Console.ForegroundColor = ConsoleColor.White;

        Console.SetCursorPosition(50, 22);
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.White;
        Console.WriteLine(" BACK          ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Black;

    }

    public static ConsoleKeyInfo SingleOptionScreenInteraction(ConsoleKeyInfo keyInfo)
    {
        while (keyInfo.Key != ConsoleKey.Spacebar && keyInfo.Key != ConsoleKey.Enter && keyInfo.Key != ConsoleKey.Escape)
        {
            keyInfo = Console.ReadKey(true);
        }

        return keyInfo;
    }

    public static void Pause()
    {
        Console.SetCursorPosition(0, 0);
        DrawHeader("Pause", "", ConsoleColor.DarkBlue, 15, 3, 4, 14);
        
    }

    public static byte PauseInteraction(ConsoleKeyInfo keyInfo, byte cursorPosition)
    {
        if (keyInfo.Key == ConsoleKey.DownArrow)
        {
            cursorPosition++;
            if (cursorPosition > 4)
            {
                cursorPosition = 1;
            }
        }
        else if (keyInfo.Key == ConsoleKey.UpArrow)
        {
            cursorPosition--;
            if (cursorPosition < 1)
            {
                cursorPosition = 4;
            }
        }

        switch (cursorPosition)
        {
            case 1:
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(50, 16);
                Console.WriteLine(" CONTINUE      ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(50, 18);
                Console.WriteLine("Restart game   ");
                Console.SetCursorPosition(50, 20);
                Console.WriteLine("How to play    ");
                Console.SetCursorPosition(50, 22);
                Console.WriteLine("Main menu      ");
                break;
            case 2:
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(50, 16);
                Console.WriteLine("Continue       ");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(50, 18);
                Console.WriteLine(" RESTART GAME  ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(50, 20);
                Console.WriteLine("How to play    ");
                Console.SetCursorPosition(50, 22);
                Console.WriteLine("Main menu      ");
                break;
            case 3:
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(50, 16);
                Console.WriteLine("Continue       ");
                Console.SetCursorPosition(50, 18);
                Console.WriteLine("Restart game   ");
                Console.SetCursorPosition(50, 20);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine(" HOW TO PLAY   ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(50, 22);
                Console.WriteLine("Main menu      ");
                break;
            case 4:
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(50, 16);
                Console.WriteLine("Continue       ");
                Console.SetCursorPosition(50, 18);
                Console.WriteLine("Restart game   ");
                Console.SetCursorPosition(50, 20);
                Console.WriteLine("How to play    ");
                Console.SetCursorPosition(50, 22);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine(" MAIN MENU     ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                break;
        }

        return cursorPosition;
    }

    public static void SettingsScreen()
    {
        Console.SetCursorPosition(0, 0);

        DrawHeader("Settings", "", ConsoleColor.DarkMagenta, 15, 3, 4, 14);
    }

    public static byte SettingsScreenInteraction(ConsoleKeyInfo keyInfo, byte cursorPosition)
    {
        if (keyInfo.Key == ConsoleKey.DownArrow)
        {
            cursorPosition++;
            if (cursorPosition > 3)
            {
                cursorPosition = 1;
            }
        }
        else if (keyInfo.Key == ConsoleKey.UpArrow)
        {
            cursorPosition--;
            if (cursorPosition < 1)
            {
                cursorPosition = 3;
            }
        }

        char[] projectileOptions = { '*', '-' };
        int chosenProjectile = Array.BinarySearch(projectileOptions, GameElement.ProjectileShape);
        ConsoleColor[] colorOptions = { ConsoleColor.Blue, ConsoleColor.Green, ConsoleColor.Red, ConsoleColor.White };
        int chosenColor = Array.BinarySearch(colorOptions, GameElement.PlayerColor);

        switch (cursorPosition)
        {
            case 1:
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(50, 16);
                Console.Write(" WEAPON        ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(50, 18);
                Console.WriteLine("Outfit color   ");
                Console.SetCursorPosition(50, 22);
                Console.WriteLine("Back           ");

                Console.SetCursorPosition(66, 18);
                Console.Write(" < ");
                Console.ForegroundColor = GameElement.PlayerColor;
                Console.Write(GameElement.PlayerColor.ToString().PadLeft(4).PadRight(5));
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" > ");

                Console.SetCursorPosition(66, 16);
                Console.Write(" < ");
                Console.ForegroundColor = GameElement.PlayerColor;
                Console.Write(projectileOptions[chosenProjectile].ToString().PadRight(3).PadLeft(5));
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" > ");
                if (keyInfo.Key == ConsoleKey.LeftArrow || keyInfo.Key == ConsoleKey.RightArrow)
                {
                    chosenProjectile = SetProjectileShape(projectileOptions, chosenProjectile);
                    Console.SetCursorPosition(66, 16);
                    Console.Write(" < ");
                    Console.ForegroundColor = GameElement.PlayerColor;
                    Console.Write(projectileOptions[chosenProjectile].ToString().PadRight(3).PadLeft(5));
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" > ");
                }
                break;
            case 2:
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(50, 16);
                Console.WriteLine("Weapon         ");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(50, 18);
                Console.WriteLine(" OUTFIT COLOR  ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(50, 22);
                Console.WriteLine("Back           ");

                chosenColor = Array.BinarySearch(colorOptions, GameElement.PlayerColor);
                Console.SetCursorPosition(66, 18);
                Console.Write(" < ");
                Console.ForegroundColor = GameElement.PlayerColor;
                Console.Write(GameElement.PlayerColor.ToString().PadLeft(4).PadRight(5));
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" > ");
                if (keyInfo.Key == ConsoleKey.LeftArrow || keyInfo.Key == ConsoleKey.RightArrow)
                {
                    chosenProjectile = SetPlayerColor(colorOptions, chosenColor, keyInfo);
                    Console.SetCursorPosition(66, 18);
                    Console.Write(" < ");
                    Console.ForegroundColor = GameElement.PlayerColor;
                    Console.Write(GameElement.PlayerColor.ToString().PadLeft(4).PadRight(5));
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" > ");
                }

                chosenProjectile = Array.BinarySearch(projectileOptions, GameElement.ProjectileShape);
                Console.SetCursorPosition(66, 16);
                Console.Write(" < ");
                Console.ForegroundColor = GameElement.PlayerColor;
                Console.Write(projectileOptions[chosenProjectile].ToString().PadRight(3).PadLeft(5));
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" > ");
                break;
            case 3:
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(50, 16);
                Console.WriteLine("Weapon         ");
                Console.SetCursorPosition(50, 18);
                Console.WriteLine("Outfit color   ");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(50, 22);
                Console.WriteLine(" BACK          ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;

                chosenProjectile = Array.BinarySearch(projectileOptions, GameElement.ProjectileShape);
                Console.SetCursorPosition(66, 16);
                Console.Write(" < ");
                Console.ForegroundColor = GameElement.PlayerColor;
                Console.Write(projectileOptions[chosenProjectile].ToString().PadRight(3).PadLeft(5));
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" > ");

                chosenColor = Array.BinarySearch(colorOptions, GameElement.PlayerColor);
                Console.SetCursorPosition(66, 18);
                Console.Write(" < ");
                Console.ForegroundColor = GameElement.PlayerColor;
                Console.Write(GameElement.PlayerColor.ToString().PadLeft(4).PadRight(5));
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" > ");
                break;
        }

        return cursorPosition;
    }

    private static int SetProjectileShape(char[] projectileOptions, int choice)
    {
        choice++;
        choice %= projectileOptions.Length;
        GameElement.ProjectileShape = projectileOptions[choice];

        return choice;
    }

    private static int SetPlayerColor(ConsoleColor[] colorOptions, int choice, ConsoleKeyInfo keyInfo)
    {
        if (keyInfo.Key == ConsoleKey.LeftArrow)
        {
            choice--;
            if (choice < 0)
            {
                choice = colorOptions.Length - 1;
            }
        }
        else
        {
            choice++;
            choice %= colorOptions.Length;
        }

        GameElement.PlayerColor = colorOptions[choice];

        return choice;
    }

    public static void CreditsScreen()
    {
        Console.SetCursorPosition(0, 0);
        DrawHeader("Credits", "Pumbaa", ConsoleColor.DarkGreen, 15, 3, 4, 14);

        string[] credits = new string[] { "Ivan Doychinov", "Lyubomir Svilenov", "Mitko Nikolov", "Plamen Kostadinov", };
        Console.ForegroundColor = ConsoleColor.White;
        byte initialRow = 12;

        for (int i = 0; i < credits.Length; i++)
        {
            Console.SetCursorPosition(50, initialRow);
            Console.Write(credits[i]);
            initialRow += 2;
        }

        Console.SetCursorPosition(50, 22);
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.White;
        Console.WriteLine(" BACK          ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Black;
    }

    public static void GameOverScreen()
    {
        Console.SetCursorPosition(0, 0);
        DrawHeader("Game", "Over", ConsoleColor.DarkGreen, 15, 3, 4, 14);
    }

    public static void GameOverScreenInteraction(GameStatus currentStatus)
    {
        int lowestHighScore = 0;

        using (StreamReader highScores = new StreamReader(@"..\..\HighScores.txt"))
        {
            string line;
            string[] entry = new string[2];

            while ((line = highScores.ReadLine()) != null)
            {
                entry = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            lowestHighScore = int.Parse(entry[1]);
        }

        bool isHighScore = false;

        if (currentStatus.Score > lowestHighScore)
        {
            isHighScore = true;
        }

        if (isHighScore)
        {
            //Enter name if high score is achived

            string playerName = string.Empty;
            Console.SetCursorPosition(35, 15);
            Console.WriteLine("You may have failed but you managed");
            Console.SetCursorPosition(35, 16);
            Console.WriteLine("to leave a mark in this history.");
            Console.SetCursorPosition(35, 17);
            Console.WriteLine("Enter the name by which you wish");
            Console.SetCursorPosition(35, 18);
            Console.WriteLine("to be remembered.");
            Console.SetCursorPosition(35, 20);
            Console.Write("-> ");

            while ((playerName = Console.ReadLine()).Length > 10)
            {
                Console.Clear();
                DrawScreen.GameOverScreen();
                Console.SetCursorPosition(35, 17);
                Console.WriteLine("Name can't be longer than 10 symbols. ");
                Console.SetCursorPosition(35, 18);
                Console.WriteLine("Try again.");
                Console.SetCursorPosition(35, 20);
                Console.Write("-> ");
            }

            try
            {
                using (StreamReader highScores = new StreamReader(@"..\..\HighScores.txt"))
                using (StreamWriter temp = new StreamWriter(@"..\..\temp.txt"))
                {
                    byte entryNumber = 1;
                    bool notWritten = true;

                    while (entryNumber <= 10)
                    {
                        string line = highScores.ReadLine();
                        string[] entry = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        if (int.Parse(entry[1]) >= currentStatus.Score || !notWritten)
                        {
                            temp.WriteLine(line);
                        }
                        else if (int.Parse(entry[1]) < currentStatus.Score && notWritten)
                        {
                            temp.WriteLine(playerName + " " + currentStatus.Score);
                            entryNumber++;
                            temp.WriteLine(line);
                            notWritten = false;
                        }

                        entryNumber++;
                    }
                }

                File.Copy(@"..\..\temp.txt", @"..\..\HighScores.txt", true);
                File.Delete(@"..\..\temp.txt");
            }
            catch (FormatException e)
            {
                Console.Clear();
                string message = e.Message;
                Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, Console.WindowHeight / 2);
                Console.WriteLine(message);
            }
            catch (ArgumentNullException e)
            {
                Console.Clear();
                string message = e.Message;
                Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, Console.WindowHeight / 2);
                Console.WriteLine(message);
            }
            catch (ArgumentException e)
            {
                Console.Clear();
                string message = e.Message;
                Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, Console.WindowHeight / 2);
                Console.WriteLine(message);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.Clear();
                string message = e.Message;
                Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, Console.WindowHeight / 2);
                Console.WriteLine(message);
            }
            catch (FileNotFoundException e)
            {
                Console.Clear();
                string message = e.Message;
                Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, Console.WindowHeight / 2);
                Console.WriteLine(message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.Clear();
                string message = e.Message;
                Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, Console.WindowHeight / 2);
                Console.WriteLine(message);
            }
            catch (IOException e)
            {
                Console.Clear();
                string message = e.Message;
                Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, Console.WindowHeight / 2);
                Console.WriteLine(message);
            }
            catch (OverflowException e)
            {
                Console.Clear();
                string message = e.Message;
                Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, Console.WindowHeight / 2);
                Console.WriteLine(message);
            }
        }
        else
        {
            //If no high score is achived, draw a fail-whale on the screen :)
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(45, 16);
            Console.WriteLine("▄██████████████▄▐█▄▄▄▄█▌");
            Console.SetCursorPosition(45, 17);
            Console.WriteLine("██████▌▄▌▄▐▐▌███▌▀▀██▀▀");
            Console.SetCursorPosition(45, 18);
            Console.WriteLine("████▄█▌▄▌▄▐▐▌▀███▄▄█▌");
            Console.SetCursorPosition(45, 19);
            Console.WriteLine("▄▄▄▄▄██████████████▀");
            Console.ReadKey(true);
        }
    }

    public static void InGameStats(int level, int lives, int score)
    {
        Console.SetCursorPosition(0, 0);
        Console.WriteLine("{0}{3}{1}{3}{1}{3}{2}", '┌', '┬', '┐', new string('─', 25));
        Console.Write("{0}{1}{2}{0}{3}", '|', "LEVEL:".PadLeft(13), level.ToString().PadRight(12), "LIVES:".PadLeft(13));

        if (lives == 1)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
        }
        else if (lives == 2)
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        else if (lives == 3)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        else if (lives == 4)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
        }
        else if (lives == 5)
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        Console.SetCursorPosition(41, 1);
        for (int i = 0; i < lives; i++)
        {
            Console.Write("♥" + " ");
        }

        Console.SetCursorPosition(52, 1);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("{0}{1}{2}{0}", '|', "SCORE:".PadLeft(13), score.ToString().PadRight(12));
        Console.WriteLine("{0}{3}{1}{3}{1}{3}{2}", '└', '┴', '┘', new string('─', 25));
    }

    public static void StoryScreen()
    {
        string[] intro = {"An evil gang of rogue ninjas has stolen the sacred scrolls of the Kendo",
                          "technique from the elders of the Telerik ninja clan.",
                          "As a young shinobi your lifelong dream has been to join this",
                          "clan. You decided to use this opportunity and prove your skills." };

        Console.ForegroundColor = ConsoleColor.Green;
        int printLineNumber = Console.WindowHeight - 8;

        for (int line = 0; line < intro.Length; line++)
        {
            string lineText = intro[line];
            Console.SetCursorPosition(3, printLineNumber);

            for (int i = 0; i < lineText.Length; i++)
            {
                Thread.Sleep(15);
                Console.Write(lineText[i]);
            }

            printLineNumber++;
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(50, Console.WindowHeight - 3);
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey(true);
    }

    public static void LevelClear()
    {
        string[] levelCleared = {"You didn't find the secred scrolls but you defeated some of the evil",
                                 "rogue ninjas and their minions. You are one step closer to your goal...",
                                 "acceptance in the infamous Telerik ninja clan." };
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        int printLineNumber = Console.WindowHeight - 7;
        for (int line = 0; line < levelCleared.Length; line++)
        {
            string lineText = levelCleared[line];
            Console.SetCursorPosition(3, printLineNumber);

            for (int i = 0; i < lineText.Length; i++)
            {
                Thread.Sleep(15);
                Console.Write(lineText[i]);
            }

            printLineNumber++;
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(50, Console.WindowHeight - 3);
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey(true);
    }

    internal static byte YesNoInteraction(string question, ConsoleKeyInfo keyInfo, byte cursorPosition)
    {
        Console.SetCursorPosition((Console.WindowWidth - question.Length) / 2, Console.WindowHeight / 2);
        Console.WriteLine(question);

        if (keyInfo.Key == ConsoleKey.DownArrow)
        {
            cursorPosition++;
            if (cursorPosition > 2)
            {
                cursorPosition = 1;
            }
        }
        else if (keyInfo.Key == ConsoleKey.UpArrow)
        {
            cursorPosition--;
            if (cursorPosition < 1)
            {
                cursorPosition = 2;
            }
        }

        switch (cursorPosition)
        {
            case 1:
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(50, 16);
                Console.WriteLine(" NO     ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(50, 18);
                Console.WriteLine("Yes     ");
                break;
            case 2:
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(50, 16);
                Console.WriteLine("No      ");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(50, 18);
                Console.WriteLine(" YES    ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                break;
        }

        return cursorPosition;
    }
}