using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DicomUtils;
using System.Drawing;

namespace DicomViewer.DicomUtils
{
    class AnnotationManager
    {
        HashSet<Annotation> Annotations = new HashSet<Annotation>();
        public event CollectionChanged AnnotationAdded;
        public event CollectionChanged AnnotationDeleted;
        public event CollectionCleared AnnotationCleared;

        public void AddAnnotation(Annotation annotation)
        {
            if (annotation != null)
            {
                Annotations.Add(annotation);
                if (this.AnnotationAdded != null)
                    this.AnnotationAdded(annotation);
            }
        }

        public void repaintAnnotations(Bitmap bmp)
        {
            foreach (Annotation annotation in Annotations)
            {
                annotation.Draw(bmp);
            }
        }

        public void DeleteLastAnnotation()
        {
            Annotation toRemove = Annotations.LastOrDefault();
            if (toRemove != null)
            {
                Annotations.Remove(toRemove);
                if (this.AnnotationDeleted != null)
                    this.AnnotationDeleted(toRemove);
            }
        }

        public Annotation GetLastAnnotation()
        {
            return Annotations.LastOrDefault();
        }

        public void Clear()
        {
            Annotations.Clear();
            if (this.AnnotationCleared != null)
                this.AnnotationCleared();
        }

        internal void DeleteAnnotation(Annotation annotation)
        {
            Annotations.Remove(annotation);
            if (this.AnnotationDeleted != null)
                this.AnnotationDeleted(annotation);
        }

        public delegate void CollectionChanged(Annotation annotation);
        public delegate void CollectionCleared();
    }
}
