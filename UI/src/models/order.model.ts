import { Car } from "./car.model";

//Correct interface
export interface Order {
    id: number;
    orderDate: Date;
    userId: number;
    carId: number;
    car?: Car;
  }

// export interface Order {
// orderDate: string;
//   brand: string;
//   model: string;
//   color: string;
//   year: number;
//   price: number;
// }