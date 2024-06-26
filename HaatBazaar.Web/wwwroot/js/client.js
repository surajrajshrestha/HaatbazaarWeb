const chat = document.getElementById('chat');
const messageInput = document.getElementById('messageInput');

const ws = new WebSocket('ws://localhost:8080');

ws.onmessage = (event) => {
    const message = document.createElement('div');
    message.textContent = event.data;
    chat.appendChild(message);
    chat.scrollTop = chat.scrollHeight;
};

messageInput.addEventListener('keypress', (event) => {
    if (event.key === 'Enter' && messageInput.value.trim() !== '') {
        const message = messageInput.value.trim();
        
        // Display the sender's message in the chat UI
        const messageElement = document.createElement('div');
        messageElement.textContent = message;
        messageElement.style.fontWeight = 'bold'; // Optional: Different style for sender's messages
        chat.appendChild(messageElement);
        chat.scrollTop = chat.scrollHeight;

        ws.send(message);
        messageInput.value = '';
    }
});
