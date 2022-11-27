import { useContext } from "react";
import IGameContext from "../../interfaces/games/IGameContext";
import { GameContext } from "../../contexts/GameContext";
import GameItem from "./GameItem";

const GameList = () => {
    const { games } = useContext(GameContext) as IGameContext;

    const getGameItems = () => {
        return games.map((game, index) => (
            <GameItem
                key={`game-${index}`}
                id={game.id}
                title={game.title}
                genre={game.genre}
                platform={game.platform}
                developer={game.developer}
                publisher={game.publisher}
                releaseDate={game.releaseDate}
                price={game.price}
                rating={game.rating}
                description={game.description}
                image={game.image}
            />
        ));
    };

    const convertGenre = (genre: number) => {
        switch (genre) {
            case 0:
                return "Action";
            case 1:
                return "ActionAdventure";
            case 2:
                return "Adventure";
            case 3:
                return "Fighting";
            case 4:
                return "Horror";
            case 5:
                return "MMO";
            case 6:
                return "Platformer";
            case 7:
                return "Puzzle";
            case 8:
                return "Racing";
            case 9:
                return "RolePlaying";
            case 10:
                return "SandBox";
            case 11:
                return "Shooter";
            case 12:
                return "Simulation";
            case 13:
                return "Sports";
            case 14:
                return "Strategy";
            default:
                return "Unknown";
        }
    };

    return (
        <section className="page-result">
            <section className="list-container">{getGameItems()}</section>
        </section>
    )

    //<h3>Games</h3>
}

export default GameList;