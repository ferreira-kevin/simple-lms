namespace lms.Domain.Utils
{
    public static class ExtensionMethods
    {
        public static bool IsNotFirstAndHasMoreThanOne(this int currentIndex, int length) => currentIndex > 0 && length > 1;
        public static bool IsNotLastAndHasMoreThanOne(this int currentIndex, int length) => currentIndex < length - 1 && length > 1;
        public static bool IsLast(this int currentIndex, int length) => currentIndex == length - 1;
    }
}
