import { ValunteerDto } from "./valunteer-dto";

export class HistoryStatusValunteerDto {


    public id: number;
    public tzId: string;
    public statusValunteerId: number;
    public silencingRingingUntilDate: Date;
    public silencingRingingFromDate: Date;
    public ValunteerDto: ValunteerDto;

}
