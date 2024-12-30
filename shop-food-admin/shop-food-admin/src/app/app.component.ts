import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { WarehouseModule } from './warehouse/warehouse.module';
import { MenuComponent } from './menu/menu/menu.component';
import { NgFor } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, WarehouseModule, MenuComponent, NgFor],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'shop-food-admin';
}
