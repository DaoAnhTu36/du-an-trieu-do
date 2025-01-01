import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  hubConnection: signalR.HubConnection = new signalR.HubConnectionBuilder().withUrl('http://localhost:1112/realtime-api').build();
  messages: { user: string; message: string }[] = [];

  constructor() {
    this.startConnection();
    this.addReceiveMessageListener();
  }

  private startConnection(): void {
    this.hubConnection
      .start()
      .then(() => console.log('SignalR Connected'))
      .catch((err) => console.error('SignalR Connection Error: ', err));
  }

  private addReceiveMessageListener(): void {
    this.hubConnection.on('ReceiveMessage', (user: string, message: string) => {
      this.messages.push({ user, message });
    });
  }

  public sendMessage(user: string, message: string): void {
    this.hubConnection
      .invoke('SendMessage', user, message)
      .catch((err) => console.error('SignalR Send Error: ', err));
  }
}
