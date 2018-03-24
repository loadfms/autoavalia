import React, { Component } from 'react';
import Header from '../Header';
import Footer from '../Footer';

export default class Panel extends Component {
	render() {
		return (
			<div className="page page--panel">
				<Header />
				<main className="main">
					<section className="section section--cards">
						<div className="container">
							<div className="cards">
								<div className="cards__item">
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