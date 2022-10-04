using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetSweeper.Core
{
    public class PathItem
    {
        string _path;
        public string Path
        {
            get => _path; 
            set => _path = value;
        }

        EnvironmentVariableTarget _target;

        public PathItem(string path, EnvironmentVariableTarget target)
        {
            _path = path;
            _target = target;
        }

        public bool PathExists()
        {
            return Directory.Exists(_path);
        }

        public bool IsDuplicate()
        {
            return Tools.GetPaths(_target).Where(x => x == _path).Count() > 1;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || this.GetType() != obj.GetType()) return false;
            PathItem other = (PathItem)obj;
            return _path.Equals(other._path);
        }

        public override int GetHashCode()
        {
            return _path.GetHashCode();
        }
    }
}
