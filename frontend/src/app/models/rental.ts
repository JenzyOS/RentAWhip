// Created by Ege Duyar - RentAWhip
export interface Rental{
    id:number;
    carId:number;
    customerId:number;
    rentDate:Date;
    returnDate?:Date;
}