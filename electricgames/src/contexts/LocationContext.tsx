import { useEffect, useState, createContext, ReactNode } from "react";
import ILocationContext from "../interfaces/locations/ILocationContext";
import ILocation from "../interfaces/locations/ILocation";
import LocationService from "../services/LocationService";

export const LocationContext = createContext<ILocationContext | null>(null);

type Props = { children: ReactNode };

const LocationProvider = ({ children }: Props) => {

    const [locations, setLocation] = useState<ILocation[]>([]);

    useEffect(() => {
        getAllLocationsFromService();
    }, []);

    const getAllLocationsFromService = async () => {
        const locations = await LocationService.getAllLocationsFromServer();
        setLocation(locations);
    }

    const getLocationByIdFromService = async (id: number) => {
        const location = await LocationService.getLocationByIdFromServer(id);
        setLocation(location);
    }

    const getLocationByNameFromService = async (name: string) => {
        const location = await LocationService.getLocationByNameFromServer(name);
        setLocation(location);
    }

    return (
        <LocationContext.Provider value={{ 
            locations, 
            getAllLocationsFromService,
            getLocationByIdFromService,
            getLocationByNameFromService
            }}>
            {children}
        </LocationContext.Provider>
    );
}

export default LocationProvider;

