import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { WarehouseModule } from './warehouse/warehouse.module';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, WarehouseModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'shop-food-admin';
}
