
namespace DelegateEventPractice
{
    class Test
    {
        int m_nCurrentIndex = 0;
        public delegate void IndexChangedEventHandler();
        public event IndexChangedEventHandler ChangeCurrentIndex;

        public void ChangePage(int nIndex)
        {
            m_nCurrentIndex = nIndex;
            ChangeCurrentIndex();
            m_nCurrentIndex = m_nCurrentIndex + 1;
        }
    }
}
