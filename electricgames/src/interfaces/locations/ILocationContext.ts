import ILocation from "./ILocation";

interface ILocationContext {
    locations: ILocation[];
    getAllLocationsFromService: () => void;
    getLocationByIdFromService: (id: number) => void;
    getLocationByNameFromService: (name: string) => void;
}

export default ILocationContext;