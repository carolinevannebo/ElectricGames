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

    return (<section className="list-container">{getGameItems()}</section>)
}

export default GameList;