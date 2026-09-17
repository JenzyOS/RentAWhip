// Created by Ege Duyar - RentAWhip
  
import { ResponseModel } from "./responseModel";

export interface ListResponseModel<T> extends ResponseModel{
    data:T[];
}