using System;
using System.Collections.Generic;
using Day8.Classes.Instructions;

namespace Day8.Classes
{
    public class Screen
    {
        private readonly int columns;
        private readonly int rows;

        public List<Pixel[,]> PixelStates = new List<Pixel[,]>();

        public Pixel[,] CurrentPixels => PixelStates.Count >= 1 ?  PixelStates[PixelStates.Count - 1] : null;
        public Pixel[,] PreviousPixels => PixelStates.Count >= 2 ? PixelStates[PixelStates.Count - 2] : null;

        public int GetActivePixelCount => CountPixels(true);
        public int GetInactivePixelCount => CountPixels(false);

        public Screen(int columns, int rows)
        {
            this.columns = columns;
            this.rows = rows;
        }

        public Pixel[,] CreateNewPixelState()
        {
            Pixel[,] pixels = new Pixel[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    pixels[i, j] = new Pixel(false);
                }
            }

            return pixels;
        }

        public void PreparenextPixelState()
        {
            PixelStates.Add(CreateNewPixelState());

            if (PreviousPixels != null)
            {
                // copy the previous state into the current state
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        CopyPixel(PreviousPixels[i, j], CurrentPixels[i, j]);
                    }
                }
            }
        }

        private void CopyPixel(Pixel source, Pixel destination)
        {
            destination.IsActive = source.IsActive;
        }

        private int CountPixels(bool filterActive)
        {
            int count = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    count += (CurrentPixels?[i, j].IsActive == filterActive) ? 1 : 0;
                }
            }

            return count;
        }

        public void ProcessInstruction(string instruction)
        {
            string command = instruction.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)[0];

            switch (command.ToLowerInvariant())
            {
                case ("rect"):
                    ProcessRectInstruction(new RectInstruction(instruction));
                    break;

                case ("rotate"):
                    ProcessRotateInstruction(new RotateInstruction(instruction));
                    break;

                default:
                    throw new Exception("Invalid command!");
            }
        }

        public void PrintGrid()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    string charToWrite = CurrentPixels[i,j].IsActive ? "#" : ".";
                    Console.Write(charToWrite);
                }

                Console.WriteLine("");
            }
        }

        public void ProcessRectInstruction(RectInstruction instruction)
        {
            PreparenextPixelState();

            for (int i = 0; i < instruction.Rows && i < rows; i++)
            {
                for (int j = 0; j < instruction.Columns && j < columns; j++)
                {
                    CurrentPixels[i, j] = new Pixel(true);
                }
            }
        }

        public void ProcessRotateInstruction(RotateInstruction instruction)
        {
            PreparenextPixelState();

            switch (instruction.TargetAxis)
            {
                case (RotateInstruction.Axis.Row):
                    for (int j = 0; j < columns; j++)
                    {
                        int fixedRow = instruction.Index;
                        int newCol = (j + instruction.Value) % columns;

                        CurrentPixels[fixedRow, newCol].IsActive = PreviousPixels[fixedRow, j].IsActive;
                    }
                    break;

                case (RotateInstruction.Axis.Column):
                    // for each row, shift active pixels by the value
                    for (int i = 0; i < rows; i++)
                    {
                        int newRow = (i + instruction.Value) % rows;
                        int fixedColumn = instruction.Index;

                        CurrentPixels[newRow, fixedColumn].IsActive = PreviousPixels[i, fixedColumn].IsActive;
                    }
                    break;

                default:
                    throw new Exception($"Unsupported TargetAxis: {instruction.TargetAxis}");
            }
        }
    }
}
