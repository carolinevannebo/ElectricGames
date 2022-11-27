import { Link, Routes, Route } from "react-router-dom";
import GetAllGamesPage from "./GetAllGamesPage";
import GetGameByIdPage from "./GetGameByIdPage";
import GetGameByTitlePage from "./GetGameByTitlePage";
import GetGamesByGenrePage from "./GetGamesByGenrePage";
import GetGamesByDeveloperPage from "./GetGamesByDeveloper";
import CreateNewGamePage from "./CreateNewGamePage";
import DeleteGamePage from "./DeleteGamePage";
import '../../styles/shared/App.css';

const GamePage = () => {

    return (
        <section className="section-container">

            <section className="page-menu">
                <h1>Game Page</h1>
                <div className="page-options">
                    <ul>
                        <li>
                            <Link to={`games/get-all-games`}>Get all Games</Link>
                        </li>
                        <li>
                            <Link to={`games/get-game-by-id`}>Find Game by ID</Link>
                        </li>
                        <li>
                            <Link to={`games/get-game-by-title`}>Find Game by Title</Link>
                        </li>
                        <li>
                            <Link to={`games/get-games-by-genre`}>Find Games by Genre</Link>
                        </li>
                        <li>
                            <Link to={`games/get-games-by-developer`}>By Developer</Link>
                        </li>
                        <li>
                            <Link to={`games/create-new-game`}>Create New Game</Link>
                        </li>
                        <li>
                            <Link to={`games/delete-game`}>Delete Game</Link>
                        </li>
                    </ul>
                </div>
            </section>

            <section className="page-content">
                <Routes>
                    <Route path="games/get-all-games" element={<GetAllGamesPage/>}></Route>
                    <Route path="games/get-game-by-id" element={<GetGameByIdPage/>}></Route>
                    <Route path="games/get-game-by-title" element={<GetGameByTitlePage/>}></Route>
                    <Route path="games/get-games-by-genre" element={<GetGamesByGenrePage/>}></Route>
                    <Route path="games/get-games-by-developer" element={<GetGamesByDeveloperPage/>}></Route>
                    <Route path="games/create-new-game" element={<CreateNewGamePage/>}></Route>
                    <Route path="games/delete-game" element={<DeleteGamePage/>}></Route>
                </Routes>
            </section>
            
        </section>
    )
}

export default GamePage;
