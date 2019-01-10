namespace HtmlDOMTree.Classes
{
    using HtmlDOMTree.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class HtmlTable : HtmlElement, ITable
    {
        private const string TableName = "table";
        private const string TableRowOpenTag = "<tr>";
        private const string TableRowCloseTag = "</tr>";
        private const string TableColOpenTag = "<td>";
        private const string TableColCloseTag = "</td>";

        private int _rows;
        private int _cols;
        private IElement[,] _tableCells;

        public HtmlTable(int rows, int cols)
                : base(TableName)
        {
            this.Rows = rows;
            this.Cols = cols;
            this._tableCells = new IElement[this.Rows, this.Cols];
        }

        public void Render(StringBuilder output,int nestedLevel)
        {
            output.Append($"<{TableName}>");

            for (int row = 0; row < this.Rows; row++)
            {
                output.Append(TableRowOpenTag);

                for (int col = 0; col < this.Cols; col++)
                {
                    output.Append(TableColOpenTag);

                    var cellData = this._tableCells[row, col].ToString();
                    output.Append(cellData);

                    output.Append(TableColCloseTag);
                }

                output.Append(TableRowCloseTag);
            }
        }

        public override string TextContent
        {
            get => throw new InvalidOperationException("Cannot get text content from Html Table");
            set => throw new InvalidOperationException("Cannot set text content to Html Table");
        }

        public override IEnumerable<IElement> ChildElements
        {
            get { throw new InvalidOperationException("HTML table don't have child element!"); }
        }

        public override void AddElement(IElement element)
        {
            throw new InvalidOperationException();
        }
        public IElement this[int row, int col]
        {
            get
            {
                ValidateRowCol(row, col);
                return this._tableCells[row, col];
            }

            set
            {
                ValidateRowCol(row, col);

                if (value == null)
                {
                    throw new ArgumentNullException("value", "Column cannot be null!");
                }
                this._tableCells[row, col] = value;
            }
        }

        private void ValidateRowCol(int row, int col)
        {
            if (row < 0 || row >= this.Rows)
            {
                throw new IndexOutOfRangeException("The row is out of bounderies!");
            }
            if (col < 0 || col >= this.Cols)
            {
                throw new IndexOutOfRangeException("The column is out of bounderies!");
            }
        }

        public int Rows
        {
            get { return this._rows; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Rows can't be less than zero");
                }

                this._rows = value;
            }
        }

        public int Cols
        {
            get { return this._cols; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Columns can't be less than zero");
                }

                this._cols = value;
            }
        }
    }
}
