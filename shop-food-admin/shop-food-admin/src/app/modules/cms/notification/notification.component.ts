import { Component } from '@angular/core';
import { SignalRService } from '../../../services/signal-r.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-notification',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './notification.component.html',
  styleUrl: './notification.component.scss'
})
export class NotificationComponent {
  user: string = '';
  message: string = '';

  constructor(public signalRService: SignalRService) { }

  sendMessage(): void {
    this.signalRService.sendMessage(this.user, this.message);
    this.message = ''; // Clear input after sending
  }
}
