using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetSweeper.Core
{
    public class PathList : IEnumerable<PathItem>
    {
        EnvironmentVariableTarget _target;
        List<PathItem> _paths;

        public PathList(EnvironmentVariableTarget target = EnvironmentVariableTarget.User)
        {
            _target = target;
            _paths = LoadPath();
        }

        private List<PathItem> LoadPath()
        {
            return Tools.GetPaths(_target)
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(x => new PathItem(x, _target))
                .ToList();
        }

        public void Refresh()
        {
            _paths = LoadPath();
        }

        public IEnumerator<PathItem> GetEnumerator()
        {
            return _paths.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
    }
}
