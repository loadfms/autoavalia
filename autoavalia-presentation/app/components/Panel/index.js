import React, { Component } from 'react';
import Header from '../Header';
import Footer from '../Footer';
import Progress from '../Progress';

export default class Panel extends Component {
	render() {
		return (
			<div className="page page--panel">
				<Header />
				<main className="main">
					<section className="section section--cards">
						<div className="container">
							<div className="cards">
								<div className="cards__item cards__item--historic">
									<div className="cards__item__internal">
										<span className="cards__item__icon"></span>
										<span className="cards__item__steps">2 de 5</span>
										<h3 className="cards__item__title">Hístorico do veículo</h3>
										<p className="cards__item__description">Dados de documentação e uso</p>
									</div>
									<Progress totalSteps={5} currentStep={4} />
								</div>
								<div className="cards__item cards__item--inside">
									<div className="cards__item__internal">
										<span className="cards__item__icon"></span>
										<span className="cards__item__steps">2 de 5</span>
										<h3 className="cards__item__title">Interior</h3>
										<p className="cards__item__description">Dados de documentação e uso</p>
									</div>
									<Progress totalSteps={8} currentStep={4} />
								</div>
								<div className="cards__item cards__item--funnel">
									<div className="cards__item__internal">
										<span className="cards__item__icon"></span>
										<span className="cards__item__steps">2 de 5</span>
										<h3 className="cards__item__title">Funilaria</h3>
										<p className="cards__item__description">Dados de documentação e uso</p>
									</div>
									<Progress totalSteps={7} currentStep={4} />
								</div>
								<div className="cards__item cards__item--tires">
									<div className="cards__item__internal">
										<span className="cards__item__icon"></span>
										<span className="cards__item__steps">2 de 5</span>
										<h3 className="cards__item__title">Pneus</h3>
										<p className="cards__item__description">Dados de documentação e uso</p>
									</div>
									<Progress totalSteps={12} currentStep={4} />
								</div>
								<div className="cards__item cards__item--eletric">
									<div className="cards__item__internal">
										<span className="cards__item__icon"></span>
										<span className="cards__item__steps">2 de 5</span>
										<h3 className="cards__item__title">Elétrica</h3>
										<p className="cards__item__description">Dados de documentação e uso</p>
									</div>
									<Progress totalSteps={10} currentStep={4} />
								</div>
								<div className="cards__item cards__item--mechanic">
									<div className="cards__item__internal">
										<span className="cards__item__icon"></span>
										<span className="cards__item__steps">2 de 5</span>
										<h3 className="cards__item__title">Mecânica</h3>
										<p className="cards__item__description">Dados de documentação e uso</p>
									</div>
									<Progress totalSteps={7} currentStep={4} />
								</div>
							</div>
						</div>
					</section>
				</main>
				<Footer />
			</div>
		);
	}
}