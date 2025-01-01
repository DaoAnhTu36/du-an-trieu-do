namespace Common.Queue
{
    public class QueueService
    {
        private readonly Queue<Action> _functionQueue;

        public QueueService()
        {
            _functionQueue = new Queue<Action>();
        }

        public void Enqueue(Action action)
        {
            _functionQueue.Enqueue(action);
        }

        public async Task ProcessQueueAsync()
        {
            while (_functionQueue.Count > 0)
            {
                var action = _functionQueue.Dequeue();
                action?.Invoke(); // Thực thi hàm
                await Task.Delay(10000); // Giả lập thời gian xử lý
            }
        }

        public int GetQueueCount()
        {
            return _functionQueue.Count;
        }
    }
}