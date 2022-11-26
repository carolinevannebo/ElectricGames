import { useContext, useState, ChangeEvent, useEffect} from "react";
import IGameContext from "../../interfaces/games/IGameContext";
import { GameContext } from "../../contexts/GameContext";
import GameList from "./GameList";

const GetGamesByDeveloper = () => {
    
    const { getGamesByDeveloperFromService } = useContext(GameContext) as IGameContext;
    const [developer, setDeveloper] = useState<string>("Rocksteady Studios");
    
    const handleChange = (event: ChangeEvent<HTMLInputElement>) => {
        const developer = event.currentTarget.value;
        setDeveloper(toTitleCase(developer));
    }

    const toTitleCase = (str: string) => {
        return str.replace(
            /\w\S*/g,
            (txt) => {
                return txt.charAt(0).toUpperCase() + txt.substring(1).toLowerCase();
            }
        );
    }
    
    useEffect(() => {
        getGamesByDeveloperFromService(developer);
    }, [developer, getGamesByDeveloperFromService]);
    
    return (
        <section className="page-content-choice">
            <h3>Find Games By Developer</h3>
    
            <div>
                <label htmlFor="developer">Enter Developer: </label>
                <input type="text" id="developer" name="developer" value={developer} onChange={handleChange} />
            </div>
    
            <section className="page-result">
                <GameList />
            </section>
        </section>
    )    
}

export default GetGamesByDeveloper;