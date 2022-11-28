import { useContext } from "react";
import ILocationContext from "../../interfaces/locations/ILocationContext";
import { LocationContext } from "../../contexts/LocationContext";
import LocationItem from "./LocationItem";

const LocationList = () => {
    const { locations } = useContext(LocationContext) as ILocationContext;

    const getLocationItems = () => {
        return locations.map((location, index) => (
            <LocationItem
                key={`location-${index}`}
                id={location.id}
                name={location.name}
                image={location.image}
            />
        ));
    };

    return (<section className="big-list-container">{getLocationItems()}</section>);
}

export default LocationList;