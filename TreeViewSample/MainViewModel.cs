using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewSample
{
    public class Comment
    {
        public string Text { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
    }

    public class MainViewModel
    {
        public IEnumerable<Comment> Comments { get; set; }

        public MainViewModel()
        {
            Comments = new[]
            {
                new Comment
                {
                    Text = "root comment #1",
                    Comments = new[]
                    {
                        new Comment
                        {
                            Text = "comment #1 #1",
                            Comments = new[]
                            {
                                new Comment
                                {
                                    Text = "comment #1 #1 #1"
                                }
                            }
                        },
                        new Comment
                        {
                            Text = "comment #1 #2"
                        }
                    }
                },
                new Comment
                {
                    Text = "root comment #2",
                    Comments = new[]
                    {
                        new Comment
                        {
                            Text = "comment #2 #1",
                        }
                    }
                }
            };
        }
    }
}
