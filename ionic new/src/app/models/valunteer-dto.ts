import { HistoryStatusValunteerDto } from './history-status-valunteer-dto';
import { ValunteerEventDto } from './volunteer-event-dto';
import { DetailsValunteerDto } from './details-valunteer-dto';

export class ValunteerDto {

        public id?: number;
        public tz: string;
        public firstName: string;
        public lastName: string;
        public phone: string;
        public cityId: number;
        public hieghtPointAddress: number;
        public personalSituationId: number;
        public widthPointAddress: number;
        public HistoryStatusValunteer: HistoryStatusValunteerDto[];
        public ValunteerEvent: ValunteerEventDto[];
        public volunteerDetail: DetailsValunteerDto;

}
